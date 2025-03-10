import { CommonModule } from '@angular/common';
import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICurrentPlayerDto, IPosition, ISquare } from '../../../app/models';
import { AttacksService, ChestItemsService, GameFlowService } from '../../../app/services';
import { AttackType, IAttackPayload, IPlayer } from '../../models/players.models';

@Component({
  selector: 'app-action-bar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './action-bar.component.html',
  styleUrls: ['./action-bar.component.css'],
  providers: [AttacksService, ChestItemsService, GameFlowService]
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
		private readonly chestItemsService: ChestItemsService,
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
			.subscribe((currentPlayer: ICurrentPlayerDto) => this.setCurrentPlayer(currentPlayer));
	}

	ngOnChanges(): void {
		this.canOpenDoor = this.selectedSquare?.isDoor && this.isAdjacentPosition(this.selectedSquare?.position);
		this.canMeleeAttack = this.selectedSquare?.player && this.isAdjacentPosition(this.selectedSquare?.position);
	}

	public onMeleeAttackAsync = (): void => this.attackAsync(AttackType.Melee);
	public onRangedAttackAsync = (): void => this.attackAsync(AttackType.Ranged);
	public onSpellAttackAsync = (): void => this.attackAsync(AttackType.Spell);

	public onHealAsync(): void {
		// TODO
	}

	public onSearchAsync(): void {
		// TODO
		this.chestItemsService.get(this.playerId).subscribe((item) => console.log(item));
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
			.subscribe((currentPlayer: ICurrentPlayerDto) => this.setCurrentPlayer(currentPlayer));
	}

	private setCurrentPlayer(currentPlayer: ICurrentPlayerDto) {
		this.currentPlayer = currentPlayer.player;

		// Ugly patch to redirect to player's turn page if user has several players in adventure
		if (this.currentPlayer.userId === this.userId) {
			this.router.navigateByUrl(
				`users/${this.userId}/players/${this.currentPlayer.id}/campaigns/${this.campaignId}/adventures/${this.adventureId}`
			);
		}
	}

	private isAdjacentPosition = (targetPosition: IPosition): boolean => {
		const currentPosition = this.userPlayer.square.position;
		return	Math.abs(currentPosition.x - targetPosition.x) + Math.abs(currentPosition.y - targetPosition.y) <= 1
	};

	private attackAsync(attackType: AttackType) {
		if (!this.selectedSquare?.player || !this.currentPlayer?.id) {
			return;
		}

		const payload: IAttackPayload = {
			attackerId: this.currentPlayer.id,
			receiverId: this.selectedSquare.player.id,
			type: attackType
		};

		this.attacksService.attackPlayerAsync(payload).subscribe(() => console.log('attacked'));
	}
}
