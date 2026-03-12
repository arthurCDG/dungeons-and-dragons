import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { of } from 'rxjs';

import {
	IAdventure,
	ICurrentPlayerDto,
	IPlayer,
	IStoredItem,
	ISquare
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
import { AdventureStore } from './adventure.store';

describe('AdventureStore', () => {
	const square: ISquare = {
		id: 1,
		roomId: 1,
		imageUrl: '',
		position: { id: 1, squareId: 1, x: 0, y: 0 }
	};
	const userPlayer: IPlayer = {
		id: 1,
		userId: 9,
		campaignId: 2,
		isAvailable: true,
		isDead: false,
		square,
		storedItems: []
	};
	const adventure: IAdventure = {
		id: 3,
		campaignId: 2,
		name: 'Goblin Ambush',
		type: 2,
		startsAt: new Date(),
		squares: [square]
	};
	const currentPlayerDto: ICurrentPlayerDto = {
		adventureId: 3,
		player: userPlayer
	};
	const storedItem: IStoredItem = {
		id: 1,
		isEquiped: false,
		playerId: 1,
		item: {
			id: 'item-1',
			name: 'Potion',
			type: 0,
			description: '',
			effects: [],
			explanation: '',
			isUnique: false,
			level: 1
		}
	};

	let routerSpy: jasmine.SpyObj<Router>;

	beforeEach(() => {
		routerSpy = jasmine.createSpyObj<Router>('Router', ['navigate']);
		routerSpy.navigate.and.resolveTo(true);

		TestBed.configureTestingModule({
			providers: [
				AdventureStore,
				{ provide: Router, useValue: routerSpy },
				{ provide: AdventuresService, useValue: { getByIdAsync: () => of(adventure) } },
				{ provide: AttacksService, useValue: { attackPlayerAsync: () => of(userPlayer) } },
				{ provide: ChestItemsService, useValue: { get: () => of(storedItem) } },
				{
					provide: GameFlowService,
					useValue: {
						getCurrentPlayer: () => of(currentPlayerDto),
						setNextCurrentPlayer: () => of(currentPlayerDto)
					}
				},
				{ provide: PlayersService, useValue: { getByIdAsync: () => of(userPlayer) } },
				{ provide: SquareMovementService, useValue: { MoveToPositionAsync: () => of({ heroId: 1, formerSquareId: 1, newSquareId: 1 }) } },
				{
					provide: SquaresService,
					useValue: {
						getByIdAsync: () => of(square),
						getPlayerIfAnyAsync: () => of(userPlayer)
					}
				}
			]
		});
	});

	it('loads the adventure route state', async () => {
		const store = TestBed.inject(AdventureStore);

		await store.load({ campaignId: 2, adventureId: 3, userId: 9, playerId: 1 });

		expect(store.isLoading()).toBeFalse();
		expect(store.adventure()?.id).toBe(3);
		expect(store.userPlayer()?.id).toBe(1);
		expect(store.currentPlayer()?.id).toBe(1);
		expect(store.squares().length).toBe(1);
	});

	it('records chest-search results in the store log', async () => {
		const store = TestBed.inject(AdventureStore);

		await store.load({ campaignId: 2, adventureId: 3, userId: 9, playerId: 1 });
		await store.searchChest();

		expect(store.logs()).toEqual(['player X retrieved the following item: Potion']);
	});
});