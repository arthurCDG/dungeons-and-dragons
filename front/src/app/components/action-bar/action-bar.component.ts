import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnChanges, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICurrentPlayerDto, IPosition, ISquare, IStoredItem } from '../../../app/models';
import { AttacksService, ChestItemsService, GameFlowService } from '../../../app/services';
import { AttackType, IAttackPayload, IPlayer } from '../../models/players.models';
import { AdventureLogService } from '../adventure-log/adventure-log.service';

@Component({
    selector: 'app-action-bar',
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

	logService = inject(AdventureLogService);

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
		this.chestItemsService.get(this.playerId)
							  .subscribe((storedItem: IStoredItem) => this.logService.addLog(`player X retrieved the following item: ${storedItem.item.name}`));
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

		// TODO - add message to say that player X has attacked player Y and dealt Z damage
		this.attacksService.attackPlayerAsync(payload).subscribe(() => this.logService.addLog(`player X dealt Y damagad to player Z (retrieve info from response)`));
	}
}
