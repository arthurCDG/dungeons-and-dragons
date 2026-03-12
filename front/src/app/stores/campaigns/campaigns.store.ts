import { computed, inject } from '@angular/core';
import { patchState, signalStore, withComputed, withMethods, withState } from '@ngrx/signals';
import { firstValueFrom } from 'rxjs';

import { ICampaign, ICreatableCampaign } from '../../models';
import { CampaignsService, CreatableCampaignsService } from '../../services';

interface CampaignsState {
	playerId: number | null;
	campaigns: ICampaign[];
	creatableCampaigns: ICreatableCampaign[];
	isLoading: boolean;
	errorMessage: string | null;
}

const initialState: CampaignsState = {
	playerId: null,
	campaigns: [],
	creatableCampaigns: [],
	isLoading: true,
	errorMessage: null
};

export const CampaignsStore = signalStore(
	withState(initialState),
	withComputed(store => ({
		hasContent: computed(() => store.campaigns().length > 0 || store.creatableCampaigns().length > 0)
	})),
	withMethods((store,
		campaignsService = inject(CampaignsService),
		creatableCampaignsService = inject(CreatableCampaignsService)) => ({
		async load(playerId: number): Promise<void> {
			patchState(store, { ...initialState, playerId, isLoading: true });

			try {
				const [campaigns, creatableCampaigns] = await Promise.all([
					firstValueFrom(campaignsService.getAsync(playerId)),
					firstValueFrom(creatableCampaignsService.getAsync(playerId))
				]);

				patchState(store, {
					campaigns,
					creatableCampaigns,
					isLoading: false,
					errorMessage: null
				});
			} catch {
				patchState(store, {
					isLoading: false,
					errorMessage: 'Unable to load the campaigns page.'
				});
			}
		}
	}))
);