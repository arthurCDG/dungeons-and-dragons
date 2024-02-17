import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICreatablePlayer } from '../../models';

@Component({
  selector: 'app-creatable-player-icon',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './creatable-player-icon.component.html',
  styleUrls: ['./creatable-player-icon.component.css']
})
export class CreatablePlayerIconComponent {
	@Input() public player: ICreatablePlayer;
	@Input() public isSelected: boolean;

	@Output() playerSelected = new EventEmitter<ICreatablePlayer>();

	public onSelectedPlayer(): void {
		this.playerSelected.emit(this.player);
	}
}
