import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayerCardComponent } from 'src/app/components/player-card/player-card.component';
import { IPlayer } from 'src/app/models';
import { PlayersService } from '../../services';

@Component({
  selector: 'app-players-page',
  standalone: true,
  imports: [CommonModule, RouterModule, PlayerCardComponent],
  templateUrl: './players-page.component.html',
  styleUrls: ['./players-page.component.css'],
  providers: [PlayersService]
})
export class PlayersPageComponent implements OnInit {
	public players: IPlayer[];
	public currentPlayer: IPlayer;

	private userId: number;

	constructor(private readonly playersService: PlayersService, private readonly route: ActivatedRoute) { }

	ngOnInit(): void {
		this.route.params.subscribe(params => this.userId = Number(params['userId']));
		this.playersService
			.getAsync(this.userId)
			.subscribe((players: IPlayer[]) => {
				this.players = players;
				if (players.length > 0) {
					this.currentPlayer = players[0];
				}
			});
	}

	public onPlayerSelected(player: IPlayer): void {
		this.currentPlayer = player;
	}
}