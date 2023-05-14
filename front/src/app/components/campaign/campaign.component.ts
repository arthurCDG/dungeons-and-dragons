import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { RoomComponent } from '../room/room.component';
import { CampaignsService } from './../../../app/services';
import { ICampaign, IRoom } from './../../../app/models/campaign.models';

@Component({
  selector: 'app-campaign',
  standalone: true,
  imports: [CommonModule, RoomComponent],
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.css'],
  providers: [CampaignsService]
})
export class CampaignComponent implements OnInit {
	public rooms: IRoom[] = [];
	constructor(private campaignsService: CampaignsService, private activatedRoute: ActivatedRoute) { }

	ngOnInit(): void {
		this.campaignsService.getAsync(1).subscribe((campaign: ICampaign) => this.rooms = campaign.rooms);
	}
}
