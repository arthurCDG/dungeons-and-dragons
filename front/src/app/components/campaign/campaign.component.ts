import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { SquareComponent } from '../square/square.component';
import { ICampaign, ISquare } from './../../../app/models/campaign.models';
import { CampaignsService } from './../../../app/services';

@Component({
  selector: 'app-campaign',
  standalone: true,
  imports: [CommonModule, SquareComponent],
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.css'],
  providers: [CampaignsService]
})
export class CampaignComponent implements OnInit {
	public campaign: ICampaign;
	public squares: ISquare[];

	public squaredIdThatNeedsToReload: number;
	public selectedSquaredId: number;

	constructor(private campaignsService: CampaignsService) { }

	ngOnInit(): void {
		this.campaignsService.getAsync(1, 1) // TODO take sessionId and campaignId
			.subscribe((campaign: ICampaign) => {
				this.campaign = campaign;
				this.squares = campaign.squares;
			});
	}

	onSquareChanged(formerSquaredId: number): void {
		this.squaredIdThatNeedsToReload = formerSquaredId;
	}

	onSquareSelected(squareId: number): void {
		this.selectedSquaredId = squareId;
	}
}
