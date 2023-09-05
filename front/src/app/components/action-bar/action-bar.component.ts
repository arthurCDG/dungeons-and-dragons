import { CommonModule } from '@angular/common';
import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICurrentPlayerDto, IPosition, ISquare } from '../../../app/models';
import { IAttackPayload, IPlayer } from '../../../app/models/players.models';
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
	@Input() public currentPlayer: IPlayer;

	public canOpenDoor?: boolean;
	public canMeleeAttack?: boolean;
	
	private playerId: number;
	private campaignId: number;

	constructor(
		private readonly attacksService: AttacksService,
		private readonly gameFlowService: GameFlowService,
		private readonly activatedRoute: ActivatedRoute
	) {}

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => {
			this.playerId = Number(params['playerId']);
			this.campaignId = Number(params['campaignId']);
		});

		this.canOpenDoor = this.selectedSquare?.isDoor && this.isAdjacentPosition(this.selectedSquare?.position);
		this.canMeleeAttack = this.selectedSquare?.player && this.isAdjacentPosition(this.selectedSquare?.position);
	}

	ngOnChanges(): void {
		this.canOpenDoor = this.selectedSquare?.isDoor && this.isAdjacentPosition(this.selectedSquare?.position);
		console.log('canOpenDoor', this.canOpenDoor);
		
		this.canMeleeAttack = this.selectedSquare?.player && this.isAdjacentPosition(this.selectedSquare?.position);
		console.log('canMeleeAttack', this.canMeleeAttack);
	}

	public onMeleeAttackAsync(): void {
		const playerId = this.playerId;
		const attack: IAttackPayload = { meleeAttack: 2 };

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
		this.gameFlowService.setNextCurrentPlayer(this.campaignId) // Should be adventureId here?
			.subscribe((currentPlayer: ICurrentPlayerDto) => {
				console.log('next current player', currentPlayer);
			});
	}

	private isAdjacentPosition = (targetPosition: IPosition): boolean => {
		console.log('this.userPlayer.square.position.x', this.userPlayer.square.position.x);
		console.log('targetPosition.x', targetPosition.x);
		console.log('this.userPlayer.square.position.y', this.userPlayer.square.position.y);
		console.log('targetPosition.y', targetPosition.y);
		
		return Math.abs(this.userPlayer.square.position.x - targetPosition.x) + Math.abs(this.userPlayer.square.position.y - targetPosition.y) <= 1
	};
}
