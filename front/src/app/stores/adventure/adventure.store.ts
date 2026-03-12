import { computed, inject } from '@angular/core';
import { Router } from '@angular/router';
import { patchState, signalStore, withComputed, withMethods, withState } from '@ngrx/signals';
import { firstValueFrom } from 'rxjs';

import { ImageType } from '../../components';
import {
	AttackType,
	IAdventure,
	ICurrentPlayerDto,
	IMovement,
	IMovementRequestPayload,
	IPlayer,
	ISquare,
	IStoredItem
} from '../../models';
import {
	AdventuresService,
	AttacksService,
	ChestItemsService,
	GameFlowService,
	PlayersService,
	SquareMovementService,
	SquaresService
} from '../../services';
import { getBackgroundImageForAdventure } from '../../pages/campaigns';

interface AdventureRouteContext {
	campaignId: number;
	adventureId: number;
	userId: number;
	playerId: number;
}

interface AdventureState {
	routeContext: AdventureRouteContext | null;
	adventure: IAdventure | null;
	squares: ISquare[];
	userPlayer: IPlayer | null;
	currentPlayer: IPlayer | null;
	selectedSquareId: number | null;
	backgroundImage: ImageType;
	isLoading: boolean;
	errorMessage: string | null;
	logs: string[];
}

const initialState: AdventureState = {
	routeContext: null,
	adventure: null,
	squares: [],
	userPlayer: null,
	currentPlayer: null,
	selectedSquareId: null,
	backgroundImage: 'campaigns-page',
	isLoading: true,
	errorMessage: null,
	logs: []
};

function isSelectableSquare(square: ISquare): boolean {
	return Boolean(square.player || square.isDoor || square.hasPillar || square.hasOpenedChest || square.hasLockedChest);
}

function isAdjacent(userPlayer: IPlayer | null, targetSquare: ISquare | null): boolean {
	if (userPlayer === null || targetSquare === null) {
		return false;
	}

	const currentPosition = userPlayer.square.position;
	const targetPosition = targetSquare.position;

	return Math.abs(currentPosition.x - targetPosition.x) + Math.abs(currentPosition.y - targetPosition.y) <= 1;
}

function updateSquaresAfterMovement(
	squares: ISquare[],
	formerSquareId: number,
	targetSquareId: number,
	formerSquare: ISquare,
	movedPlayer: IPlayer
): ISquare[] {
	return squares.map(square => {
		if (square.id === formerSquareId) {
			return { ...square, ...formerSquare, player: undefined };
		}

		if (square.id === targetSquareId) {
			return { ...square, player: movedPlayer };
		}

		return square;
	});
}

function updateSquarePlayer(squares: ISquare[], squareId: number, player: IPlayer): ISquare[] {
	return squares.map(square => square.id === squareId ? { ...square, player } : square);
}

async function navigateToCurrentUserTurn(
	router: Router,
	routeContext: AdventureRouteContext | null,
	currentPlayer: IPlayer | null
): Promise<void> {
	if (routeContext === null || currentPlayer === null) {
		return;
	}

	if (currentPlayer.userId === routeContext.userId && currentPlayer.id !== routeContext.playerId) {
		await router.navigate([
			'/users',
			routeContext.userId,
			'players',
			currentPlayer.id,
			'campaigns',
			routeContext.campaignId,
			'adventures',
			routeContext.adventureId
		]);
	}
}

export const AdventureStore = signalStore(
	withState(initialState),
	withComputed(store => {
		const selectedSquare = computed(() => {
			const selectedSquareId = store.selectedSquareId();
			return store.squares().find(square => square.id === selectedSquareId) ?? null;
		});

		const isUserTurn = computed(() => {
			const currentPlayer = store.currentPlayer();
			const routeContext = store.routeContext();
			return currentPlayer !== null && routeContext !== null && currentPlayer.userId === routeContext.userId;
		});

		return {
			selectedSquare,
			isUserTurn,
			canAttackTarget: computed(() => Boolean(selectedSquare()?.player)),
			canMeleeAttack: computed(() => Boolean(selectedSquare()?.player) && isAdjacent(store.userPlayer(), selectedSquare())),
			canOpenDoor: computed(() => Boolean(selectedSquare()?.isDoor) && isAdjacent(store.userPlayer(), selectedSquare()))
		};
	}),
	withMethods((store,
		adventuresService = inject(AdventuresService),
		attacksService = inject(AttacksService),
		chestItemsService = inject(ChestItemsService),
		gameFlowService = inject(GameFlowService),
		playersService = inject(PlayersService),
		squareMovementService = inject(SquareMovementService),
		squaresService = inject(SquaresService),
		router = inject(Router)) => {
		const refreshCurrentPlayer = async (): Promise<ICurrentPlayerDto | null> => {
			const routeContext = store.routeContext();

			if (routeContext === null) {
				return null;
			}

			const currentPlayerDto = await firstValueFrom(gameFlowService.getCurrentPlayer(routeContext.adventureId));
			const currentUserPlayer = store.userPlayer();

			patchState(store, {
				currentPlayer: currentPlayerDto.player,
				userPlayer: currentUserPlayer !== null && currentUserPlayer.id === currentPlayerDto.player.id
					? { ...currentUserPlayer, ...currentPlayerDto.player, square: currentUserPlayer.square }
					: currentUserPlayer
			});

			return currentPlayerDto;
		};

		const appendLog = (log: string): void => {
			patchState(store, { logs: [...store.logs(), log] });
		};

		return {
			async load(routeContext: AdventureRouteContext): Promise<void> {
				patchState(store, {
					...initialState,
					routeContext,
					isLoading: true
				});

				try {
					const [adventure, userPlayer, currentPlayerDto] = await Promise.all([
						firstValueFrom(adventuresService.getByIdAsync(routeContext.campaignId, routeContext.adventureId)),
						firstValueFrom(playersService.getByIdAsync(routeContext.userId, routeContext.playerId)),
						firstValueFrom(gameFlowService.getCurrentPlayer(routeContext.adventureId))
					]);

					patchState(store, {
						adventure,
						squares: adventure.squares,
						userPlayer,
						currentPlayer: currentPlayerDto.player,
						backgroundImage: getBackgroundImageForAdventure(adventure.type),
						isLoading: false,
						errorMessage: null
					});

					await navigateToCurrentUserTurn(router, routeContext, currentPlayerDto.player);
				} catch {
					patchState(store, {
						isLoading: false,
						errorMessage: 'Unable to load the adventure.'
					});
				}
			},

			selectSquare(squareId: number): void {
				patchState(store, { selectedSquareId: squareId });
			},

			async handleSquareClick(square: ISquare): Promise<void> {
				if (isSelectableSquare(square)) {
					patchState(store, { selectedSquareId: square.id });
					return;
				}

				const routeContext = store.routeContext();

				if (routeContext === null) {
					return;
				}

				try {
					const payload: IMovementRequestPayload = {
						playerId: routeContext.playerId,
						squareId: square.id
					};

					const movement: IMovement = await firstValueFrom(squareMovementService.MoveToPositionAsync(payload));
					const [formerSquare, movedPlayer] = await Promise.all([
						firstValueFrom(squaresService.getByIdAsync(movement.formerSquareId)),
						firstValueFrom(squaresService.getPlayerIfAnyAsync(square.id))
					]);

					patchState(store, {
						squares: updateSquaresAfterMovement(store.squares(), movement.formerSquareId, square.id, formerSquare, movedPlayer),
						userPlayer: movedPlayer,
						selectedSquareId: null,
						errorMessage: null
					});

					await refreshCurrentPlayer();
				} catch {
					patchState(store, { errorMessage: 'Unable to move the player.' });
				}
			},

			async searchChest(): Promise<void> {
				const routeContext = store.routeContext();

				if (routeContext === null) {
					return;
				}

				try {
					const storedItem: IStoredItem = await firstValueFrom(chestItemsService.get(routeContext.playerId));
					appendLog(`player X retrieved the following item: ${storedItem.item.name}`);
					await refreshCurrentPlayer();
				} catch {
					patchState(store, { errorMessage: 'Unable to search the chest.' });
				}
			},

			async attackSelectedSquare(attackType: AttackType): Promise<void> {
				const selectedSquare = store.selectedSquare();
				const currentPlayer = store.currentPlayer();

				if (selectedSquare?.player === undefined || currentPlayer?.id === undefined) {
					return;
				}

				try {
					const attackedPlayer = await firstValueFrom(attacksService.attackPlayerAsync({
						attackerId: currentPlayer.id,
						receiverId: selectedSquare.player.id,
						type: attackType
					}));

					patchState(store, {
						squares: updateSquarePlayer(store.squares(), selectedSquare.id, attackedPlayer),
						errorMessage: null
					});

					appendLog('player X dealt Y damage to player Z (retrieve info from response)');
					await refreshCurrentPlayer();
				} catch {
					patchState(store, { errorMessage: 'Unable to attack the selected target.' });
				}
			},

			async endTurn(): Promise<void> {
				const routeContext = store.routeContext();

				if (routeContext === null) {
					return;
				}

				try {
					const currentPlayerDto = await firstValueFrom(gameFlowService.setNextCurrentPlayer(routeContext.adventureId));
					patchState(store, {
						currentPlayer: currentPlayerDto.player,
						errorMessage: null
					});

					await navigateToCurrentUserTurn(router, routeContext, currentPlayerDto.player);
				} catch {
					patchState(store, { errorMessage: 'Unable to end the current turn.' });
				}
			},

			appendLog,

			clearLogs(): void {
				patchState(store, { logs: [] });
			}
		};
	})
);