import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IHero, IMonster } from 'src/app/models/players.models';
import { RoomComponent } from '../room/room.component';
import { ICampaign } from './../../../app/models/campaign.models';
import { CampaignsService } from './../../../app/services';

@Component({
  selector: 'app-campaign',
  standalone: true,
  imports: [CommonModule, RoomComponent],
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.css'],
  providers: [CampaignsService]
})
export class CampaignComponent implements OnInit {
	public campaign: ICampaign;
	public heroesBySquareId: Map<number, IHero>;
	public monstersBySquareId: Map<number, IMonster>;

	constructor(private campaignsService: CampaignsService, private activatedRoute: ActivatedRoute) { }

	ngOnInit(): void {
		this.campaignsService.getAsync(1).subscribe((campaign: ICampaign) => { // TODO retrieve Id dynamically
			this.campaign = campaign;

			this.heroesBySquareId = campaign?.heroes.reduce((map, hero) => {
				return map.set(hero?.squareId, hero);
			}, new Map<number, IHero>());

			this.monstersBySquareId = campaign?.monsters.reduce((map, monster) => {
				return map.set(monster?.squareId, monster);
			}, new Map<number, IMonster>());
		});
	}
}
