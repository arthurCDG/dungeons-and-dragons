import { computed, inject } from '@angular/core';
import { Router } from '@angular/router';
import { patchState, signalStore, withComputed, withMethods, withState } from '@ngrx/signals';
import { firstValueFrom } from 'rxjs';

import { ImageType } from '../../components';
import { ICampaignPayload, ICreatableCampaign, IPlayer, IUserDto } from '../../models';
import { getBackgroundImageForCampaign } from '../../pages/campaigns';
import { AvailableDungeonMastersService, AvailablePlayersService, CampaignsService, PlayersService } from '../../services';

interface CampaignCreationRouteContext {
	userId: number;
	playerId: number;
}

interface CampaignCreationState {
	routeContext: CampaignCreationRouteContext | null;
	selectedCampaign: ICreatableCampaign | null;
	currentPlayer: IPlayer | null;
	availableUsers: IUserDto[];
	availablePlayers: IPlayer[];
	backgroundImage: ImageType;
	isLoading: boolean;
	isSubmitting: boolean;
	errorMessage: string | null;
}

const initialState: CampaignCreationState = {
	routeContext: null,
	selectedCampaign: null,
	currentPlayer: null,
	availableUsers: [],
	availablePlayers: [],
	backgroundImage: 'campaigns-page',
	isLoading: true,
	isSubmitting: false,
	errorMessage: null
};

export const CampaignCreationStore = signalStore(
	withState(initialState),
	withComputed(store => ({
		maxSelectableHeroes: computed(() => Math.max((store.selectedCampaign()?.maxPlayers ?? 1) - 1, 0))
	})),
	withMethods((store,
		campaignsService = inject(CampaignsService),
		playersService = inject(PlayersService),
		availableDungeonMastersService = inject(AvailableDungeonMastersService),
		availablePlayersService = inject(AvailablePlayersService),
		router = inject(Router)) => ({
		async load(routeContext: CampaignCreationRouteContext, selectedCampaign: ICreatableCampaign): Promise<void> {
			patchState(store, {
				...initialState,
				routeContext,
				selectedCampaign,
				backgroundImage: getBackgroundImageForCampaign(selectedCampaign.type),
				isLoading: true
			});

			try {
				const [currentPlayer, availableUsers, availablePlayers] = await Promise.all([
					firstValueFrom(playersService.getByIdAsync(routeContext.userId, routeContext.playerId)),
					firstValueFrom(availableDungeonMastersService.getAsync()),
					firstValueFrom(availablePlayersService.getAsync())
				]);

				patchState(store, {
					currentPlayer,
					availableUsers,
					availablePlayers: availablePlayers.filter(player => player.id !== routeContext.playerId && player.campaignId === null),
					isLoading: false,
					errorMessage: null
				});
			} catch {
				patchState(store, {
					isLoading: false,
					errorMessage: 'Unable to load the campaign creation page.'
				});
			}
		},

		async createCampaign(payload: ICampaignPayload): Promise<void> {
			const routeContext = store.routeContext();

			if (routeContext === null) {
				return;
			}

			patchState(store, { isSubmitting: true, errorMessage: null });

			try {
				const campaign = await firstValueFrom(campaignsService.postAsync(payload));

				patchState(store, { isSubmitting: false });

				await router.navigate([
					'/users',
					routeContext.userId,
					'players',
					routeContext.playerId,
					'campaigns',
					campaign.id
				]);
			} catch {
				patchState(store, {
					isSubmitting: false,
					errorMessage: 'Unable to create the campaign.'
				});
			}
		}
	}))
);