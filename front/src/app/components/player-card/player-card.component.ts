import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IPlayer } from 'src/app/models';

@Component({
  selector: 'app-player-card',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './player-card.component.html',
  styleUrls: ['./player-card.component.css']
})
export class PlayerCardComponent {
	@Input() public player: IPlayer;
	@Output() playerSelected = new EventEmitter<IPlayer>();

	public onPlayerCardClick(): void {
		this.playerSelected.emit(this.player);
	}
}
