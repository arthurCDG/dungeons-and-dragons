import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ICreatablePlayer, IPlayer } from 'src/app/models';

@Component({
  selector: 'app-creatable-player-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './creatable-player-card.component.html',
  styleUrls: ['./creatable-player-card.component.css']
})
export class CreatablePlayerCardComponent {
	@Input() public player: ICreatablePlayer;
}
