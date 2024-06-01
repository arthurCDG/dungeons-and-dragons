import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import {
	BackArrowComponent,
	CreatablePlayerClassCardComponent,
	CreatablePlayerSpeciesCardComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	SelectedPlayerComponent
} from '../../../app/components';
import { Class, ICreatablePlayer, IPlayerCreationPayload, PlayerGender, Species } from '../../models';
import { CreatablePlayersService, PlayersService } from '../../services';

@Component({
  selector: 'app-player-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	CreatablePlayerClassCardComponent,
	CreatablePlayerSpeciesCardComponent,
	SelectedPlayerComponent,
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
	public selectedClass?: Class;
	public selectedSpecies?: Species;
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
				this.selectedClass = this.creatablePlayers[0].class.type;
			}

			this.isLoading = false;
		});
	}

	selectPlayerClass(playerClass: Class): void {
		this.selectedClass = playerClass;
	}

	selectPlayerSpecies(playerSpecies: Species): void {
		this.selectedSpecies = playerSpecies;
	}

	onSubmit(): void {
		const payload: IPlayerCreationPayload = {
			class: this.selectedClass!,
			name: 'MUST COME FRON THE TEXT INPUT', // TODO
			gender: PlayerGender.NonBinary, // TODO - MUST COME FRON THE RADIO INPUT
			species: this.selectedSpecies!
		};

		console.log(payload);

		this.playersService.createAsync(this.userId, payload).subscribe(
			() => this.router.navigate(['..'], { relativeTo: this.activatedRoute })
		);
	}
}