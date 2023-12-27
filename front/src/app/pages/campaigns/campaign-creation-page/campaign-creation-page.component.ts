import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from "@angular/material/icon";
import { Observable } from 'rxjs';
import { CreatableCampaignCardComponent } from '../../../components/creatable-campaign-card/creatable-campaign-card.component';
import { ICampaign, ICampaignPayload, ICreatableCampaign, IPlayer, IUserDto } from '../../../models';
import { AvailableDungeonMastersService, AvailablePlayersService, CampaignsService, CreatableCampaignsService } from '../../../services';

@Component({
  selector: 'app-campaign-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	ReactiveFormsModule,
	MatSelectModule,
	MatFormFieldModule,
	MatIconModule,
	CreatableCampaignCardComponent
],
  templateUrl: './campaign-creation-page.component.html',
  styleUrls: ['./campaign-creation-page.component.css'],
  providers: [
	CreatableCampaignsService,
	CampaignsService,
	AvailableDungeonMastersService,
	AvailablePlayersService
  ]
})
export class CampaignCreationPageComponent implements OnInit {
	public creatableCampaigns: ICreatableCampaign[] = [];
	public selectedCampaign: ICreatableCampaign;
	public users$: Observable<IUserDto[]>;
	public players$: Observable<IPlayer[]>;
	public isLoading: boolean = true;
	
	private playerId: number;

	dungeonMasterCtrl = this.fb.control<number | null>(null);
	playersCtrl = this.fb.array<number>([]);
	campaignCreationForm = this.fb.group({
		dungeonMaster: this.dungeonMasterCtrl,
		heroes: this.playersCtrl
	});

	constructor(
		private readonly fb: FormBuilder,
		private readonly campaignsService: CampaignsService,
		private readonly creatableCampaignsService: CreatableCampaignsService,
		private readonly availableDungeonMastersService: AvailableDungeonMastersService,
		private readonly availablePlayersService: AvailablePlayersService,
		private readonly router: Router,
		private readonly activatedRoute: ActivatedRoute
	) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.playerId = Number(params['playerId']));

		this.creatableCampaignsService
			.getAsync(this.playerId)
			.subscribe(creatableCampaigns => {
				this.creatableCampaigns = creatableCampaigns;
			});

		this.users$ = this.availableDungeonMastersService.getAsync();
		this.players$ = this.availablePlayersService.getAsync();

		this.isLoading = false;
	}

	ngOnChanges(): void {
		if (this.selectedCampaign) {
			for (let i = 0; i < this.selectedCampaign.maxPlayers; i++) {
				this.playersCtrl.push(this.fb.control(null)); // Probably does not work ... need to bind name to control
			}
		}
	}

	onSubmit(): void {
		const payload: ICampaignPayload = {
			type: this.selectedCampaign.type,
			playerIds: [
				this.playerId,
				// ...this.playersCtrl.value // + add values from controls
			],
			dungeonMasterUserId: this.dungeonMasterCtrl.value
		};

		this.campaignsService
			.postAsync(payload)
			.subscribe((campaign: ICampaign) => this.router.navigate(['..', campaign.id], { relativeTo: this.activatedRoute }));
	}

	onCreatableCampaignClicked(creatableCampaign: ICreatableCampaign): void {
		this.selectedCampaign = creatableCampaign;
	}

	onDeleteClicked(index: number): void {
		this.playersCtrl.at(index).setValue(null);
	}
}
