import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { HeroComponent } from '../hero/hero.component';
import { InteractiveElementComponent } from '../interactive-element/interactive-element.component';
import { MonsterComponent } from '../monster/monster.component';
import { IMovement, IMovementRequestPayload, ISquare } from './../../../app/models/campaign.models';
import { IHero, IMonster, IPlayer } from './../../../app/models/players.models';
import { SquareMovementService, SquaresService } from './../../../app/services';

@Component({
  selector: 'app-square',
  standalone: true,
  imports: [CommonModule, HeroComponent, MonsterComponent, InteractiveElementComponent],
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

	public hero: IHero | null = null;
	public monster: IMonster | null = null;

	public selected: boolean;
	public tileStyle: string;
	
	constructor(
		private readonly squaresService: SquaresService,
		private readonly squareMovementService: SquareMovementService
	) { }

	ngOnInit(): void {
		const randomNumber: number = Math.ceil((Math.random() * 3));
		this.tileStyle = `type-${randomNumber}`;

		this.squaresService.getByIdAsync(this.square.id).subscribe((player: IPlayer) => {
			
			if ((player as IHero)?.class != null) {
				this.hero = player as IHero;
			}

			if ((player as IMonster)?.type != null) {
				this.monster = player as IMonster
			}
		})
	}

	ngOnChanges(): void {
		if (this.squareNeedsToReload) {
			this.squaresService.getByIdAsync(this.square.id).subscribe((player: IPlayer) => {
				if ((player as IHero)?.class != null) {
					this.hero = player as IHero;
				} else if ((player as IMonster)?.type != null) {
					this.monster = player as IMonster
				} else {
					this.hero = null;
					this.monster = null;
				}
			})
		}

		this.selected = this.squareIsSelected;
	}

	public onSquareClicked(): void {
		if (this.hero || this.monster) {
			this.squareSelected.emit(this.square.id);
			return;
		}

		const payload: IMovementRequestPayload = {
			heroId: 9,
			squareId: this.square.id
		};

		this.squareMovementService.MoveToPositionAsync(payload).subscribe((movement: IMovement) => {
			this.squareChanged.emit(movement.formerSquareId);

			this.squaresService.getByIdAsync(this.square.id).subscribe((player: IPlayer) => {
				if ((player as IHero)?.class != null) {
					this.hero = player as IHero;
				}
	
				if ((player as IMonster)?.type != null) {
					this.monster = player as IMonster
				}
			})
		});
	}
}
