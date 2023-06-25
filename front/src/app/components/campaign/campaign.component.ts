import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { ICampaign } from './../../../app/models/campaign.models';
import { CampaignsService } from './../../../app/services';

@Component({
  selector: 'app-campaign',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.css'],
  providers: [CampaignsService]
})
export class CampaignComponent implements OnInit {
	public campaigns: ICampaign[];

	constructor(private campaignsService: CampaignsService) { }

	ngOnInit(): void {
		this.campaignsService.getAsync(5, 11) // TODO take playerId and campaignId from ParamsService
			.subscribe((campaigns: ICampaign[]) => {
				this.campaigns = campaigns;
			});
	}
}
