import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import {
	BackArrowComponent,
	CreatablePlayerCardComponent,
	CreatablePlayerIconComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	SelectedPlayerComponent
} from '../../../app/components';
import { ICreatablePlayer, IPlayerCreationPayload, PlayerGender, Species } from '../../models';
import { CreatablePlayersService, PlayersService } from '../../services';

@Component({
  selector: 'app-player-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	CreatablePlayerCardComponent,
	SelectedPlayerComponent,
	CreatablePlayerIconComponent,
	PageWrapperComponent,
	PageBackgroundImageComponent,
	BackArrowComponent
  ],
  templateUrl: './player-creation-page.component.html',
  styleUrls: ['./player-creation-page.component.css'],
  providers: [
	PlayersService,
	CreatablePlayersService
  ]
})
export class PlayerCreationPageComponent implements OnInit {
	private userId: number;

	public creatablePlayers: ICreatablePlayer[] = [];
	public selectedPlayer?: ICreatablePlayer;
	public isLoading: boolean = true;
	
	constructor(
		private readonly playersService: PlayersService,
		private readonly creatablePlayersService: CreatablePlayersService,
		private readonly router: Router,
		private readonly activatedRoute: ActivatedRoute
	) { }
	
	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.userId = Number(params['userId']));

		this.creatablePlayersService.getAsync(this.userId).subscribe(creatablePlayers => {
			this.creatablePlayers = creatablePlayers;
			if (this.creatablePlayers.length) {
				this.selectedPlayer = this.creatablePlayers[0];
			}

			this.isLoading = false;
		});
	}

	selectPlayer(player: ICreatablePlayer): void {
		this.selectedPlayer = player;
	}

	onSubmit(): void {
		const payload: IPlayerCreationPayload = {
			class: this.selectedPlayer!.class.type,
			name: 'MUST COME FRON THE TEXT INPUT', // TODO
			gender: PlayerGender.NonBinary, // TODO - MUST COME FRON THE RADIO INPUT
			species: Species.CarrionCrawler // TODO - MUST COME FRON THE SPECIES RADIO INPUT
		};

		console.log(payload);

		this.playersService.createAsync(this.userId, payload).subscribe(
			() => this.router.navigate(['..'], { relativeTo: this.activatedRoute })
		);
	}
}