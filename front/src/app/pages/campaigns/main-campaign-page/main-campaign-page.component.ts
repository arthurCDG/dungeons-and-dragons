import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { AdventureType, IAdventure, ICampaign, ICreatableAdventure } from '../../../models';
import { AdventuresService, CampaignsService, CreatableAdventuresService } from '../../../services';
import { CommonModule } from '@angular/common';
import { CreatableAdventureCardComponent } from '../../../components/creatable-adventure-card/creatable-adventure-card.component';
import { AdventureCardComponent } from '../../../components/adventure-card/adventure-card.component';

@Component({
  selector: 'app-campaigns-page',
  standalone: true,
  imports: [
	CommonModule,
	RouterModule,
	CreatableAdventureCardComponent,
	AdventureCardComponent
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
	public mainCampaign: ICampaign;
	public creatableAdventures: ICreatableAdventure[] = [];

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.campaignId = Number(params['campaignId']));
	
		this.campaignsService.getByIdAsync(this.campaignId).subscribe((campaign: ICampaign) => {
			this.mainCampaign = campaign;
		});

		this.creatableAdventuresService.getAsync(this.campaignId).subscribe((creatableAdventures: ICreatableAdventure[]) => {
			this.creatableAdventures = creatableAdventures;
		});
	}
}
