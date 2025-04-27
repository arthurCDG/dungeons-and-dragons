import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { RouterModule } from '@angular/router';

import { getLokalisedClassName, getLokalisedSpeciesName } from '../../../helpers';
import { Class, IPlayer, PlayerGender, Species } from '../../../models';
import { AvailablePlayersService } from '../../../services';

@Component({
    selector: 'app-player-card',
    imports: [CommonModule, RouterModule],
    templateUrl: './player-card.component.html',
    styleUrls: ['./player-card.component.css'],
    providers: [AvailablePlayersService]
})
export class PlayerCardComponent {
	@Input({ required: true}) public player: IPlayer;
	@Input() public isSelected: boolean;

	@Output() playerSelected = new EventEmitter<IPlayer>();

	private readonly availablePlayersService = inject(AvailablePlayersService);

	public onPlayerCardClick(): void {
		this.playerSelected.emit(this.player);
	}

	public togglePlayerAvailability(): void {
		if (this.player.isAvailable) {
			this.availablePlayersService.markAsUnavailableAsync(this.player.id)
										.subscribe(() => this.player.isAvailable = false);
		} else {
			this.availablePlayersService.markAsAvailableAsync(this.player.id)
										.subscribe(() => this.player.isAvailable = true);
		}
	}

	public getLokalisedClassName = (classType: Class, gender: PlayerGender): string => {
		return getLokalisedClassName(classType, gender);
	}
	public getLokalisedSpeciesName = (speciesType: Species, gender: PlayerGender): string => {
		return getLokalisedSpeciesName(speciesType, gender);
	}
}
