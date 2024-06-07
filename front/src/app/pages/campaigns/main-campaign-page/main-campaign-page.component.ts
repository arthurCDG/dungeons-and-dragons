import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

import { ICampaign, ICreatableAdventure } from '../../../models';
import { AdventuresService, CampaignsService, CreatableAdventuresService } from '../../../services';
import { AdventureCardComponent, BackArrowComponent, CreatableAdventureCardComponent, EmptyStateBodyComponent, ImageType, LoadingSpinnerComponent, PageBackgroundImageComponent, PageWrapperComponent } from '../../../components';
import { getBackgroundImageForCampaign } from '../helpers';

@Component({
  selector: 'app-campaigns-page',
  standalone: true,
  imports: [
	CommonModule,
	RouterModule,
	CreatableAdventureCardComponent,
	AdventureCardComponent,
	BackArrowComponent,
	EmptyStateBodyComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	LoadingSpinnerComponent
],
  templateUrl: './main-campaign-page.component.html',
  styleUrls: ['./main-campaign-page.component.css'],
  providers: [
	CampaignsService,
	AdventuresService,
	CreatableAdventuresService
  ]
})
export class MainCampaignPageComponent implements OnInit {
	constructor(
		private readonly campaignsService: CampaignsService,
		private readonly creatableAdventuresService: CreatableAdventuresService,
		private readonly activatedRoute: ActivatedRoute
	) { }

	private campaignId: number;
	public campaign: ICampaign;
	public creatableAdventures: ICreatableAdventure[] = [];

	public isLoading = true;
	public backgroundImage: ImageType = 'campaigns-page';

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.campaignId = Number(params['campaignId']));
	
		this.campaignsService.getByIdAsync(this.campaignId).subscribe((campaign: ICampaign) => {
			this.campaign = campaign;
			this.backgroundImage = getBackgroundImageForCampaign(campaign.type);
			this.isLoading = false;
		});

		this.creatableAdventuresService.getAsync(this.campaignId).subscribe((creatableAdventures: ICreatableAdventure[]) => {
			this.creatableAdventures = creatableAdventures;
		});
	}
}
