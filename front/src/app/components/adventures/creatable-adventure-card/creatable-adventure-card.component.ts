import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { AdventureType, IAdventure, ICreatableAdventure } from '../../models';
import { AdventuresService } from '../../services';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-creatable-adventure-card',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './creatable-adventure-card.component.html',
  styleUrls: ['./creatable-adventure-card.component.css'],
  providers: [AdventuresService]
})
export class CreatableAdventureCardComponent implements OnInit {
	 @Input() creatableAdventure: ICreatableAdventure;

	private campaignId: number;

	 constructor(
		private readonly router: Router,
		private readonly activatedRoute: ActivatedRoute,
		private readonly adventuresService: AdventuresService
	) {	}
	
	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.campaignId = Number(params['campaignId']));
	}

	 startAdventureAsync(adventureType: AdventureType): void {
		this.adventuresService
			.startAsync(this.campaignId, adventureType)
			.subscribe((adventure: IAdventure) => this.router.navigate(
				['adventures', adventure.id],
				{ relativeTo: this.activatedRoute }
			));
	}
}
