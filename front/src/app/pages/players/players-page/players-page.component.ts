import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

import { firstValueFrom } from 'rxjs';
import {
	BackArrowComponent,
	ImageType,
	LoadingSpinnerComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	PlayerCardComponent,
	SelectedPlayerComponent
} from '../../../components';
import { IPlayer, IUserDto, PlayerRole } from '../../../models';
import { AvailableDungeonMastersService, PlayersService, UsersService } from '../../../services';

@Component({
    selector: 'app-players-page',
    imports: [
        CommonModule,
        RouterModule,
        PlayerCardComponent,
        BackArrowComponent,
        SelectedPlayerComponent,
        PageWrapperComponent,
        PageBackgroundImageComponent,
        LoadingSpinnerComponent
    ],
    templateUrl: './players-page.component.html',
    styleUrls: ['./players-page.component.css'],
    providers: [
        PlayersService,
        UsersService,
        AvailableDungeonMastersService
    ]
})
export class PlayersPageComponent implements OnInit {
	public players: IPlayer[]
	public currentPlayer: IPlayer;
	public isLoading = true;

	public user: IUserDto;

	public readonly maxPlayersCount = 4;
	public backgroundImage: ImageType = 'players-creation-page';

	private userId: number;

	constructor(
		private readonly playersService: PlayersService,
		private readonly usersService: UsersService,
		private readonly availableDungeonMastersService: AvailableDungeonMastersService,
		private readonly route: ActivatedRoute
	) { }

	async ngOnInit(): Promise<void> {
		this.userId = await firstValueFrom(this.route.params).then(params => Number(params['userId']));

		this.playersService
			.getAsync(this.userId)
			.subscribe((players: IPlayer[]) => {
				this.players = players.filter(p => p.profile?.role === PlayerRole.Hero);
				if (players.length > 0) {
					this.currentPlayer = players[0];
				}
			})

		this.usersService
			.getByIdAsync(this.userId)
			.subscribe((user: IUserDto) => {
				this.user = user;
				});
				
		this.isLoading = false;
	}

	public toggleUserAvailability(): void {
		if (this.user.isAvailable) {
			this.availableDungeonMastersService
				.markAsUnavailableAsync(this.userId)
				.subscribe(() => this.user.isAvailable = false);
		} else {
			this.availableDungeonMastersService
				.markAsAvailableAsync(this.userId)
				.subscribe(() => this.user.isAvailable = true);
		}
	}

	public isSelected(player: IPlayer): boolean {
		return this.currentPlayer === player;
	}

	public onPlayerSelected(player: IPlayer): void {
		this.currentPlayer = player;
	}
}