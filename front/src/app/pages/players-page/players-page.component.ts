import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

import { IPlayer } from '../../models';
import { PlayersService } from '../../services';
import { BackArrowComponent, PlayerCardComponent, SelectedPlayerComponent, PageWrapperComponent, PageBackgroundImageComponent, ImageType } from '../../../app/components';

@Component({
  selector: 'app-players-page',
  standalone: true,
  imports: [
	CommonModule,
	RouterModule,
	PlayerCardComponent,
	BackArrowComponent,
	SelectedPlayerComponent,
	PageWrapperComponent,
	PageBackgroundImageComponent
],
  templateUrl: './players-page.component.html',
  styleUrls: ['./players-page.component.css'],
  providers: [PlayersService]
})
export class PlayersPageComponent implements OnInit {
	public players: IPlayer[] = [];
	public currentPlayer: IPlayer;

	public backgroundImage: ImageType = 'hollbrook-background-campaign-image';

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

	public isSelected(player: IPlayer): boolean {
		return this.currentPlayer === player;
	}

	public onPlayerSelected(player: IPlayer): void {
		this.currentPlayer = player;
	}
}