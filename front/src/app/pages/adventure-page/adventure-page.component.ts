import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ActionBarComponent } from '../../components/action-bar/action-bar.component';
import { IAdventure, ICurrentPlayerDto, IPlayer, ISquare } from '../../models';
import { SquareComponent } from '../../components/square/square.component';
import { PlayersService, AdventuresService, GameFlowService } from '../../services';

@Component({
  selector: 'app-adventure-page',
  standalone: true,
  imports: [CommonModule, RouterModule, ActionBarComponent, SquareComponent],
  templateUrl: './adventure-page.component.html',
  styleUrls: ['./adventure-page.component.css'],
  providers: [AdventuresService, PlayersService, GameFlowService]
})
export class AdventurePageComponent implements OnInit {
	public adventure: IAdventure;
	public squares: ISquare[];
	public squaredIdThatNeedsToReload: number;
	public selectedSquaredId?: number;
	public selectedSquare?: ISquare;
	public userPlayer: IPlayer;
	public currentPlayer: IPlayer;
	public isLoading = true;
	
	private campaignId: number;
	private adventureId: number;
	private userId: number;
	private playerId: number;

	constructor(
		private readonly playersService: PlayersService,
		private readonly adventuresService: AdventuresService,
		private readonly gameFlowService: GameFlowService,
		private readonly activatedRoute: ActivatedRoute
	) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => {
			this.campaignId = Number(params['campaignId']);
			this.adventureId = Number(params['adventureId']);
			this.userId = Number(params['userId']);
			this.playerId = Number(params['playerId']);
		});

		this.adventuresService.getByIdAsync(this.campaignId, this.adventureId).subscribe((adventure: IAdventure) => {
				this.adventure = adventure;
				this.squares = adventure.squares;
		});

		this.getUserPlayer();
		this.getCurrentPlayer();

		this.isLoading = false;
	}

	onSquareChanged(formerSquaredId: number): void {
		this.squaredIdThatNeedsToReload = formerSquaredId;
		// Update userPlayer's position to be this.s
	}

	onSquareSelected(squareId: number): void {
		this.selectedSquaredId = squareId;
		this.selectedSquare = this.squares.find(s => s.id === this.selectedSquaredId);
	}

	private getUserPlayer(): void {
		this.playersService.getByIdAsync(this.userId, this.playerId)
			.subscribe((userPlayer: IPlayer) => {
				console.log('userPlayer', userPlayer);
				this.userPlayer = userPlayer;
			});
	}

	private getCurrentPlayer(): void {
		this.gameFlowService.getCurrentPlayer(this.adventureId)
			.subscribe((currentPlayer: ICurrentPlayerDto) => {
				console.log('current player >>>>', currentPlayer);
				if (currentPlayer.player?.id === this.userPlayer?.id) {
					this.currentPlayer = currentPlayer.player;
				}
			});
	}

}
