import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayersService } from '../../services';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { HeroClass, IPlayer } from 'src/app/models';

@Component({
  selector: 'app-players-page',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './players-page.component.html',
  styleUrls: ['./players-page.component.css'],
  providers: [PlayersService]
})
export class PlayersPageComponent implements OnInit {
	public players: IPlayerCard[] = [];
	public currentPlayer: IPlayerCard;
	
	private userId: number;

	constructor(private readonly playersService: PlayersService, private readonly route: ActivatedRoute) { }

	ngOnInit(): void {
		this.route.params.subscribe(params => this.userId = Number(params['userId']));
	
		this.playersService.getAsync(this.userId).subscribe((players: IPlayer[]) => {
			this.players = this.forgeplayerCards(players);
		});
	}

	public onPlayerCardClick(player: IPlayerCard): void {
		this.currentPlayer = player;
	}

	private forgeplayerCards(players: IPlayer[]): IPlayerCard[] {
		let playerCards: IPlayerCard[] = [];
	
		const heroes: IPlayerCard[] = players
			.filter(p => p.profile.class != null && p.profile.race != null)
			.map(p => this.forgeHeroPlayerCard(p));

		playerCards.push(...heroes);
		
		if (players.some(p => p.profile.monsterType != null)) {
			const campaignsCount: number = players.filter(p => p.profile.monsterType != null).length;  // TODO fix this
			playerCards.push({
				id: 0,
				name: 'Maître du dongeon',
				image: '',
				campaignsCount,
				type: 'dungeonMaster'
			});
		}

		return playerCards;
	}

	private forgeHeroPlayerCard(hero: IPlayer): IPlayerCard {
		return {
			id: hero.id,
			name: hero.profile.firstName,
			image: hero.profile.imageUrl,
			class: hero.profile.class,
			campaignsCount: hero.campaigns.length,
			type: 'hero'
		}
	}
}

interface IPlayerCard {
	id: number;
	name: string;
	image: string;
	type: playerType;
	campaignsCount: number;
	class?: HeroClass;
}

type playerType = 'hero' | 'dungeonMaster';