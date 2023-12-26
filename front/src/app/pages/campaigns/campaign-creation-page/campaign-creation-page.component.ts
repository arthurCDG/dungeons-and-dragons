import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { AvailablePlayersService, CampaignsService, CreatableCampaignsService, UsersService } from '../../../services';
import { AdventureType, IAvailablePlayer, ICampaign, ICampaignPayload, ICreatableCampaign, IPlayer, IUserDto } from '../../../models';
import { MatSelectModule } from '@angular/material/select';
import { CreatableCampaignCardComponent } from '../../../components/creatable-campaign-card/creatable-campaign-card.component';
import { Observable } from 'rxjs';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-campaign-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	ReactiveFormsModule,
	MatSelectModule,
	MatFormFieldModule,
	CreatableCampaignCardComponent
],
  templateUrl: './campaign-creation-page.component.html',
  styleUrls: ['./campaign-creation-page.component.css'],
  providers: [
	CreatableCampaignsService,
	CampaignsService,
	UsersService,
	AvailablePlayersService
  ]
})
export class CampaignCreationPageComponent implements OnInit {
	public creatableCampaigns: ICreatableCampaign[] = [];
	public selectedCampaign?: ICreatableCampaign;
	public users$: Observable<IUserDto[]>;
	public players$: Observable<IAvailablePlayer[]>;
	public isLoading: boolean = true;
	
	private playerId: number;

	campaignTypeCtrl = this.fb.control(null);
	campaignCreationForm = this.fb.group({
		campaignType: this.campaignTypeCtrl,
	});

	constructor(
		private readonly fb: FormBuilder,
		private readonly campaignsService: CampaignsService,
		private readonly creatableCampaignsService: CreatableCampaignsService,
		private readonly usersService: UsersService,
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

	this.users$ = this.usersService.getAsync();
	this.players$ = this.availablePlayersService.getAsync();

	this.isLoading = false;

	this.campaignTypeCtrl.valueChanges.subscribe(campaignType => {
		this.selectedCampaign = this.creatableCampaigns.find(creatableCampaign => creatableCampaign.type === campaignType)
	});
  }

  onSubmit(): void {
	const payload: ICampaignPayload = {
		type: this.campaignTypeCtrl.value!,
		playerIds: [
			this.playerId
		],
		adventurePayload: {
			type: AdventureType.GoblinBandits
		}
	};

	this.campaignsService
		.postAsync(payload)
		.subscribe((campaign: ICampaign) => this.router.navigate(['..', campaign.id], { relativeTo: this.activatedRoute }));
	}

	onCreatableCampaignClicked(creatableCampaign: ICreatableCampaign): void {
		this.selectedCampaign = creatableCampaign;
	}
}
