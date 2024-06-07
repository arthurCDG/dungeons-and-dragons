import { CommonModule } from '@angular/common';
import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICurrentPlayerDto, IPosition, ISquare } from '../../../app/models';
import { IAttackPayload, IPlayer } from '../../models/players.models';
import { AttacksService, GameFlowService } from '../../../app/services';

@Component({
  selector: 'app-action-bar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './action-bar.component.html',
  styleUrls: ['./action-bar.component.css'],
  providers: [AttacksService, GameFlowService]
})
export class ActionBarComponent implements OnInit, OnChanges {
	@Input() public selectedSquare?: ISquare;
	@Input() public userPlayer: IPlayer;
	@Input() public currentPlayer?: IPlayer | null;;

	public canOpenDoor?: boolean;
	public canMeleeAttack?: boolean;
	public userId: number;
	
	private playerId: number;
	private adventureId: number;
	private campaignId: number;

	constructor(
		private readonly attacksService: AttacksService,
		private readonly gameFlowService: GameFlowService,
		private readonly activatedRoute: ActivatedRoute,
		private readonly router: Router
	) {}

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => {
			this.userId = Number(params['userId']);
			this.playerId = Number(params['playerId']);
			this.adventureId = Number(params['adventureId']);
			this.campaignId = Number(params['campaignId']);
		});

		this.canOpenDoor = this.selectedSquare?.isDoor && this.isAdjacentPosition(this.selectedSquare?.position);
		this.canMeleeAttack = this.selectedSquare?.player && this.isAdjacentPosition(this.selectedSquare?.position);

		this.gameFlowService
			.getCurrentPlayer(this.adventureId)
			.subscribe((currentPlayer: ICurrentPlayerDto) => {
				this.currentPlayer = currentPlayer.player;

				if (this.currentPlayer.userId === this.userId) {
					this.router.navigateByUrl(
						`users/${this.userId}/players/${this.currentPlayer.id}/campaigns/${this.campaignId}/adventures/${this.adventureId}`
					);
				}
			});
	}

	ngOnChanges(): void {
		this.canOpenDoor = this.selectedSquare?.isDoor && this.isAdjacentPosition(this.selectedSquare?.position);
		this.canMeleeAttack = this.selectedSquare?.player && this.isAdjacentPosition(this.selectedSquare?.position);
	}

	public onMeleeAttackAsync(): void {
		const playerId = this.playerId;
		const attack: IAttackPayload = { meleeAttack: 2 }; // Test - TODO remove

		this.attacksService.attackPlayerAsync(playerId, attack).subscribe(() => console.log('attacked'));
	}

	public onRangeAttackAsync(): void {
		// TODO
	}

	public onHealAsync(): void {
		// TODO
	}

	public onSearchAsync(): void {
		// TODO
	}

	public onOpenDoorAsync(): void {
		// TODO
	}

	public onEndTurnAsync(): void {
		this.setNextCurrentPlayer();
	}

	private setNextCurrentPlayer(): void {
		this.gameFlowService
			.setNextCurrentPlayer(this.adventureId)
			.subscribe((currentPlayer: ICurrentPlayerDto) => {
				this.currentPlayer = currentPlayer.player;

				if (this.currentPlayer.userId === this.userId) {
					this.router.navigateByUrl(
						`users/${this.userId}/players/${this.currentPlayer.id}/campaigns/${this.campaignId}/adventures/${this.adventureId}`
					);
				}
			});
	}

	private isAdjacentPosition = (targetPosition: IPosition): boolean => {
		const currentPosition = this.userPlayer.square.position;
		return	Math.abs(currentPosition.x - targetPosition.x) + Math.abs(currentPosition.y - targetPosition.y) <= 1
	};
}
