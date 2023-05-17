import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeroComponent } from '../hero/hero.component';
import { MonsterComponent } from '../monster/monster.component';
import { InteractiveElementComponent } from '../interactive-element/interactive-element.component';
import { ISquare } from './../../../app/models/campaign.models';
import { SquaresService } from './../../../app/services';
import { IHero, IMonster, IPlayer } from './../../../app/models/players.models';

@Component({
  selector: 'app-square',
  standalone: true,
  imports: [CommonModule, HeroComponent, MonsterComponent, InteractiveElementComponent],
  templateUrl: './square.component.html',
  styleUrls: ['./square.component.css'],
  providers: [SquaresService]
})
export class SquareComponent implements OnInit {
	@Input() square: ISquare;

	public hero: IHero | null = null;
	public monster: IMonster | null = null;
	
	constructor(private squaresService: SquaresService) { }

	ngOnInit(): void {
		this.squaresService.getByIdAsync(this.square?.id).subscribe((player: IPlayer) => {
			if ((player as IHero)?.class != null) {
				console.log('hero', player);
				
				this.hero = player as IHero;
			}

			if ((player as IMonster)?.type != null) {
				console.log('monster', player);

				this.monster = player as IMonster
			}
		})
	}
}
