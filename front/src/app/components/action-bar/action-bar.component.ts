import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ICurrentPlayerDto } from 'src/app/models';
import { IAttackPayload, IPlayer } from './../../../app/models/players.models';
import { AttacksService, GameFlowService } from './../../../app/services';

@Component({
  selector: 'app-action-bar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './action-bar.component.html',
  providers: [AttacksService, GameFlowService]
})
export class ActionBarComponent implements OnInit {
	private player?: IPlayer;

	constructor(private readonly attacksService: AttacksService, private readonly gameFlowService: GameFlowService) {}

	ngOnInit(): void {
		// this.gameFlowService.getCurrentPlayer(1) // TODO change
		// 	.subscribe((currentPlayer: ICurrentPlayerDto) => {
		// 		console.log('currentPlayer', currentPlayer);
		// 		this.hero = currentPlayer.hero ?? null;
		// 		this.monster = currentPlayer.monster ?? null;
		// 	})
	}

	onAttackAsync(): void {
		const playerId = 17;
		const attack: IAttackPayload = { meleeAttack: 2 };

		this.attacksService.attackPlayerAsync(playerId, attack).subscribe(() => console.log('attacked'));
	}

	onEndTurnAsync(): void {
		this.gameFlowService.getNextCurrentPlayer(1) // TODO change
			.subscribe((currentPlayer: ICurrentPlayerDto) => {
				console.log('next current player', currentPlayer);
				this.player = currentPlayer.player;
			});
	}
}
