import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Location } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from "@angular/material/icon";
import { MatSelectModule } from '@angular/material/select';
import { Observable } from 'rxjs';
import { CampaignType, ICampaign, ICampaignPayload, ICreatableCampaign, IPlayer, IUserDto } from '../../../models';
import { AvailableDungeonMastersService, AvailablePlayersService, CampaignsService, PlayersService } from '../../../services';
import { BackArrowComponent, ImageType, PageBackgroundImageComponent, PageWrapperComponent } from '../../../components';

@Component({
	selector: 'app-campaign-creation-page',
	standalone: true,
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
	providers: [
		CampaignsService,
		AvailableDungeonMastersService,
		AvailablePlayersService,
		PlayersService
	]
})
export class CampaignCreationPageComponent implements OnInit {
	public selectedCampaign?: ICreatableCampaign | null = null;
	public currentPlayer?: IPlayer | null = null;
	public isLoading: boolean = true;

	public backgroundImage: ImageType | null = null;

	public users$: Observable<IUserDto[]>;
	public players$: Observable<IPlayer[]>;
	
	private userId: number;
	private playerId: number;
	private routeData: ICampaignCreationPageRouteData;

	dungeonMasterCtrl = this.fb.control<IUserDto | null>(null);
	heroesCtrl = this.fb.record<IPlayer | null>({});
	campaignCreationForm = this.fb.group({
		dungeonMaster: this.dungeonMasterCtrl,
		heroes: this.heroesCtrl
	});

	constructor(
		private readonly fb: FormBuilder,
		private readonly campaignsService: CampaignsService,
		private readonly playersService: PlayersService,
		private readonly availableDungeonMastersService: AvailableDungeonMastersService,
		private readonly availablePlayersService: AvailablePlayersService,
		private readonly router: Router,
		private readonly activatedRoute: ActivatedRoute,
		private readonly location: Location
	) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => {
			this.playerId = Number(params['playerId']);
			this.userId = Number(params['userId']);
		});
		this.playersService.getByIdAsync(this.userId, this.playerId).subscribe(player => this.currentPlayer = player);

		this.users$ = this.availableDungeonMastersService.getAsync();
		this.players$ = this.availablePlayersService.getAsync();

		this.routeData = this.location.getState() as ICampaignCreationPageRouteData;
		if (!this.routeData.creatableCampaign) {
			this.router.navigate(['..'], { relativeTo: this.activatedRoute });
		}
		
		this.selectedCampaign = this.routeData.creatableCampaign;
		this.backgroundImage = this.getBackgroundImage(this.selectedCampaign.type);
		for (let i = 0; i < this.selectedCampaign.maxPlayers; i++) {
			this.heroesCtrl.addControl(`hero_${i}`, this.fb.control<IPlayer | null>(null))
		}

		this.isLoading = false;
	}

	onSubmit(): void {
		const playerIds: number[] = [this.playerId];
		for (let heroField in this.heroesCtrl.controls) {
			if (this.heroesCtrl.controls[heroField].value) {
				playerIds.push(this.heroesCtrl.controls[heroField].value!.id);
			}
		}

		const payload: ICampaignPayload = {
			type: this.selectedCampaign!.type,
			playerIds,
			dungeonMasterUserId: this.dungeonMasterCtrl.value?.id
		};

		this.campaignsService
			.postAsync(payload)
			.subscribe((campaign: ICampaign) => this.router.navigate(['..', campaign.id], { relativeTo: this.activatedRoute }));
	}

	public deleteHeroesControlValue(event: Event, index: number): void {
		event.stopPropagation();
		this.heroesCtrl.controls[`hero_${index}`]?.setValue(null);
	}

	public deleteDungeonMasterValue(event: Event): void {
		event.stopPropagation();
		this.dungeonMasterCtrl.setValue(null);
	}

	private getBackgroundImage(type: CampaignType): ImageType | null {
		switch(type) {
			case CampaignType.HollbrooksLiberation:
				return 'hollbrook-background-campaign-image';
			case CampaignType.InpursuitOfTheDarkArmy:
				return 'inpursuit-of-the-dark-army-campaign-image';
			case CampaignType.WrathOfTheLich:
			default:
				return 'wrath-of-the-lich-campaign-image';
		}
	}
}

interface ICampaignCreationPageRouteData {
	creatableCampaign: ICreatableCampaign;
}
