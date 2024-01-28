import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CreatablePlayerCardComponent } from 'src/app/components/creatable-player-card/creatable-player-card.component';
import { HeaderComponent } from '../../components/header/header.component';
import { ICreatablePlayer, IPlayerCreationPayload } from '../../models';
import { CreatablePlayersService, PlayersService } from '../../services';

@Component({
  selector: 'app-player-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	HeaderComponent,
	CreatablePlayerCardComponent
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
			playerType: this.selectedPlayer!.type,
		};

		this.playersService.createAsync(this.userId, payload).subscribe(
			() => this.router.navigate(['..'], { relativeTo: this.activatedRoute })
		);
	}
}