import { CommonModule } from '@angular/common';
import { Component, Input, inject } from '@angular/core';
import { RouterModule } from '@angular/router';

import { getLokalisedClassName, getLokalisedSpeciesName } from '../../../helpers';
import { Class, IPlayer, PlayerGender, Species } from '../../../models';
import { PlayersStore } from '../../../stores';

@Component({
    selector: 'app-player-card',
    imports: [CommonModule, RouterModule],
    templateUrl: './player-card.component.html',
    styleUrls: ['./player-card.component.css']
})
export class PlayerCardComponent {
	@Input({ required: true}) public player: IPlayer;
	public readonly playersStore = inject(PlayersStore);

	public onPlayerCardClick(): void {
		this.playersStore.selectPlayer(this.player.id);
	}

	public onTogglePlayerAvailability(event: Event): void {
		event.stopPropagation();
		void this.playersStore.togglePlayerAvailability(this.player.id);
	}

	public getLokalisedClassName = (classType: Class, gender: PlayerGender): string => {
		return getLokalisedClassName(classType, gender);
	}
	public getLokalisedSpeciesName = (speciesType: Species, gender: PlayerGender): string => {
		return getLokalisedSpeciesName(speciesType, gender);
	}
}
