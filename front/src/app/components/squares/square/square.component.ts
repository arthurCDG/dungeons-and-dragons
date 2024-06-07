import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IMovement, IMovementRequestPayload, IPlayer, ISquare } from '../../../models';
import { SquareMovementService, SquaresService } from '../../../services';
import { PlayerComponent } from '../../players/player/player.component';
import { DecorativeElementComponent } from '../decorative-element/decorative-element.component';
import { InteractiveElementComponent } from '../interactive-element/interactive-element.component';

@Component({
  selector: 'app-square',
  standalone: true,
  imports: [CommonModule, PlayerComponent, InteractiveElementComponent, DecorativeElementComponent],
  templateUrl: './square.component.html',
  styleUrls: ['./square.component.css'],
  providers: [SquaresService, SquareMovementService]
})
export class SquareComponent implements OnInit, OnChanges {
	@Input() square: ISquare;
	@Input() squareIsSelected: boolean;
	@Input() squareNeedsToReload?: boolean;

	@Output() squareChanged = new EventEmitter<number>();
	@Output() squareSelected = new EventEmitter<number>();

	public player?: IPlayer;
	public playerId: number;
	public selected: boolean;
	public tileStyle: string;
	
	constructor(
		private readonly squaresService: SquaresService,
		private readonly squareMovementService: SquareMovementService,
		private readonly activatedRoute: ActivatedRoute
	) { }

	ngOnInit(): void {
		const randomNumber: number = Math.ceil((Math.random() * 3));
		this.tileStyle = `type-${randomNumber}`;

		this.player = this.square.player;
		if (this.player) {
			console.log('this.player', this.player);
		}

		this.activatedRoute.params.subscribe(params => this.playerId = Number(params['playerId']));
	}

	ngOnChanges(): void {
		if (this.squareNeedsToReload) {
			this.squaresService.getPlayerIfAnyAsync(this.square.id).subscribe((player: IPlayer) => {
				if (player) {
					this.player = player;
				} else {
					this.player = undefined;
				}
			})
		}

		this.selected = this.squareIsSelected;
	}

	public onSquareClicked(): void {
		if (this.player || this.square.isDoor || this.square.hasPillar || this.square.hasOpenedChest || this.square.hasLockedChest) {
			this.squareSelected.emit(this.square.id);
		} else {
			this.movePlayerToPosition();
		}
	}

	private movePlayerToPosition() {
		const payload: IMovementRequestPayload = {
			playerId: this.playerId,
			squareId: this.square.id
		};

		this.squareMovementService.MoveToPositionAsync(payload).subscribe((movement: IMovement) => {
			this.squareChanged.emit(movement.formerSquareId);

			this.squaresService.getPlayerIfAnyAsync(this.square.id).subscribe((player: IPlayer) => {
				if (player != null) {
					this.player = player;
				}
			});
		});
	}
}
