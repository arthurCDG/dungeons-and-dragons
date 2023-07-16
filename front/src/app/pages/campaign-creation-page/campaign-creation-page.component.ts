import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { CampaignsService, CreatableCampaignsService } from '../../services';
import { AdventureType, ICampaignPayload, ICreatableCampaign } from '../../models';
import { MatRadioModule } from '@angular/material/radio';

@Component({
  selector: 'app-campaign-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	ReactiveFormsModule,
	MatRadioModule
],
  templateUrl: './campaign-creation-page.component.html',
  styleUrls: ['./campaign-creation-page.component.css'],
  providers: [
	CreatableCampaignsService,
	CampaignsService
  ]
})
export class CampaignCreationPageComponent implements OnInit {
	private playerId: number;

	public creatableCampaigns: ICreatableCampaign[] = [];
	public selectedCampaign?: ICreatableCampaign;
	public isLoading: boolean = true;

	campaignTypeCtrl = this.fb.control(null);
	campaignCreationForm = this.fb.group({
		campaignType: this.campaignTypeCtrl,
	});

	constructor(
		private readonly fb: FormBuilder,
		private readonly campaignsService: CampaignsService,
		private readonly creatableCampaignsService: CreatableCampaignsService,
		private readonly router: Router,
		private readonly activatedRoute: ActivatedRoute
	) { }

  ngOnInit(): void {
	this.activatedRoute.params.subscribe(params => this.playerId = Number(params['playerId']));

	this.creatableCampaignsService.getAsync(this.playerId).subscribe(creatableCampaigns => {
		this.creatableCampaigns = creatableCampaigns;
		this.isLoading = false;
	});

	this.campaignTypeCtrl.valueChanges.subscribe(campaignType => {
		this.selectedCampaign = this.creatableCampaigns.find(creatableCampaign => creatableCampaign.type === campaignType)
	});
  }

  onSubmit(): void {
	const payload: ICampaignPayload = {
		type: this.campaignTypeCtrl.value!,
		playerIds: [],
		adventurePayload: {
			type: AdventureType.GoblinBandits
		}
	};

	this.campaignsService.postAsync(payload).subscribe(() => this.router.navigate(['../'], { relativeTo: this.activatedRoute }));
	}
}
