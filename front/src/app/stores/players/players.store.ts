import { computed, inject } from '@angular/core';
import { patchState, signalStore, withComputed, withMethods, withState } from '@ngrx/signals';
import { firstValueFrom } from 'rxjs';

import { IPlayer, IUserDto, PlayerRole } from '../../models';
import { AvailableDungeonMastersService, AvailablePlayersService, PlayersService, UsersService } from '../../services';

interface PlayersState {
	userId: number | null;
	players: IPlayer[];
	selectedPlayerId: number | null;
	user: IUserDto | null;
	isLoading: boolean;
	errorMessage: string | null;
}

const initialState: PlayersState = {
	userId: null,
	players: [],
	selectedPlayerId: null,
	user: null,
	isLoading: true,
	errorMessage: null
};

export const PlayersStore = signalStore(
	withState(initialState),
	withComputed(store => ({
		currentPlayer: computed(() => store.players().find(player => player.id === store.selectedPlayerId()) ?? null),
		canCreatePlayer: computed(() => store.players().length < 4)
	})),
	withMethods((store,
		playersService = inject(PlayersService),
		usersService = inject(UsersService),
		availableDungeonMastersService = inject(AvailableDungeonMastersService),
		availablePlayersService = inject(AvailablePlayersService)) => ({
		async load(userId: number): Promise<void> {
			patchState(store, { ...initialState, userId, isLoading: true });

			try {
				const [players, user] = await Promise.all([
					firstValueFrom(playersService.getAsync(userId)),
					firstValueFrom(usersService.getByIdAsync(userId))
				]);

				const availableHeroes = players.filter(player => player.profile?.role === PlayerRole.Hero);

				patchState(store, {
					players: availableHeroes,
					selectedPlayerId: availableHeroes[0]?.id ?? null,
					user,
					isLoading: false,
					errorMessage: null
				});
			} catch {
				patchState(store, {
					isLoading: false,
					errorMessage: 'Unable to load the players page.'
				});
			}
		},

		selectPlayer(playerId: number): void {
			patchState(store, { selectedPlayerId: playerId });
		},

		async toggleUserAvailability(): Promise<void> {
			const user = store.user();
			const userId = store.userId();

			if (user === null || userId === null) {
				return;
			}

			try {
				if (user.isAvailable) {
					await firstValueFrom(availableDungeonMastersService.markAsUnavailableAsync(userId));
				} else {
					await firstValueFrom(availableDungeonMastersService.markAsAvailableAsync(userId));
				}

				patchState(store, {
					user: { ...user, isAvailable: !user.isAvailable },
					errorMessage: null
				});
			} catch {
				patchState(store, { errorMessage: 'Unable to update the dungeon master availability.' });
			}
		},

		async togglePlayerAvailability(playerId: number): Promise<void> {
			const player = store.players().find(currentPlayer => currentPlayer.id === playerId);

			if (player === undefined) {
				return;
			}

			try {
				if (player.isAvailable) {
					await firstValueFrom(availablePlayersService.markAsUnavailableAsync(playerId));
				} else {
					await firstValueFrom(availablePlayersService.markAsAvailableAsync(playerId));
				}

				patchState(store, {
					players: store.players().map(currentPlayer =>
						currentPlayer.id === playerId
							? { ...currentPlayer, isAvailable: !currentPlayer.isAvailable }
							: currentPlayer
					),
					errorMessage: null
				});
			} catch {
				patchState(store, { errorMessage: 'Unable to update the player availability.' });
			}
		}
	}))
);