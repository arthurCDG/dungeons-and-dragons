import { CommonModule } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Location } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from "@angular/material/icon";
import { MatSelectModule } from '@angular/material/select';
import { BackArrowComponent, PageBackgroundImageComponent, PageWrapperComponent } from '../../../components';
import { ICampaignPayload, ICreatableCampaign, IPlayer, IUserDto } from '../../../models';
import { CampaignCreationStore } from '../../../stores';

@Component({
    selector: 'app-campaign-creation-page',
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatFormFieldModule,
        MatIconModule,
        BackArrowComponent,
        PageWrapperComponent,
        PageBackgroundImageComponent
    ],
    templateUrl: './campaign-creation-page.component.html',
    styleUrls: ['./campaign-creation-page.component.css'],
    providers: [CampaignCreationStore]
})
export class CampaignCreationPageComponent implements OnInit {
	public readonly campaignCreationStore = inject(CampaignCreationStore);
	private readonly activatedRoute = inject(ActivatedRoute);
	private readonly destroyRef = inject(DestroyRef);
	private readonly fb = inject(FormBuilder);
	private readonly router = inject(Router);
	private readonly location = inject(Location);

	dungeonMasterCtrl = this.fb.control<IUserDto | null>(null);
	heroesCtrl = this.fb.record<IPlayer | null>({});
	campaignCreationForm = this.fb.group({
		dungeonMaster: this.dungeonMasterCtrl,
		heroes: this.heroesCtrl
	});

	ngOnInit(): void {
		const routeData = this.location.getState() as ICampaignCreationPageRouteData;

		if (!routeData.creatableCampaign) {
			this.router.navigate(['..'], { relativeTo: this.activatedRoute });
			return;
		}

		for (let i = 0; i < routeData.creatableCampaign.maxPlayers - 1; i++) {
			this.heroesCtrl.addControl(`hero_${i}`, this.fb.control<IPlayer | null>(null));
		}

		this.activatedRoute.params
			.pipe(takeUntilDestroyed(this.destroyRef))
			.subscribe(params => {
				void this.campaignCreationStore.load(
					{
						playerId: Number(params['playerId']),
						userId: Number(params['userId'])
					},
					routeData.creatableCampaign
				);
			});
	}

	onSubmit(): void {
		const currentPlayer = this.campaignCreationStore.currentPlayer();
		const selectedCampaign = this.campaignCreationStore.selectedCampaign();

		if (currentPlayer === null || selectedCampaign === null) {
			return;
		}

		const playerIds: number[] = [currentPlayer.id];
		for (let heroField in this.heroesCtrl.controls) {
			if (this.heroesCtrl.controls[heroField].value) {
				playerIds.push(this.heroesCtrl.controls[heroField].value!.id);
			}
		}

		const payload: ICampaignPayload = {
			type: selectedCampaign.type,
			playerIds,
			dungeonMasterUserId: this.dungeonMasterCtrl.value?.id
		};

		void this.campaignCreationStore.createCampaign(payload);
	}

	public deleteHeroesControlValue(event: Event, index: number): void {
		event.stopPropagation();
		this.heroesCtrl.controls[`hero_${index}`]?.setValue(null);
	}

	public deleteDungeonMasterValue(event: Event): void {
		event.stopPropagation();
		this.dungeonMasterCtrl.setValue(null);
	}

	public isPlayerSelectedElsewhere(playerId: number, currentIndex: number): boolean {
		return Object.entries(this.heroesCtrl.controls).some(([controlName, control]) => {
			if (controlName === `hero_${currentIndex}`) {
				return false;
			}

			return control.value?.id === playerId;
		});
	}
}

interface ICampaignCreationPageRouteData {
	creatableCampaign: ICreatableCampaign;
}
