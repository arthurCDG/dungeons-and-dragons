import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { getLokalisedClassName, getLokalisedSpeciesName } from '../../../helpers';
import { Class, IPlayer, PlayerGender, Species } from '../../../models';

@Component({
  selector: 'app-player-card',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './player-card.component.html',
  styleUrls: ['./player-card.component.css']
})
export class PlayerCardComponent {
	@Input({ required: true}) public player: IPlayer;
	@Input() public isSelected: boolean;

	@Output() playerSelected = new EventEmitter<IPlayer>();

	public onPlayerCardClick(): void {
		this.playerSelected.emit(this.player);
	}

	public getLokalisedClassName = (classType: Class, gender: PlayerGender): string => {
		return getLokalisedClassName(classType, gender);
	}
	public getLokalisedSpeciesName = (speciesType: Species, gender: PlayerGender): string => {
		return getLokalisedSpeciesName(speciesType, gender);
	}
}
