import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ICreatablePlayer } from 'src/app/models';

@Component({
  selector: 'app-creatable-player-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './creatable-player-card.component.html',
  styleUrls: ['./creatable-player-card.component.css']
})
export class CreatablePlayerCardComponent {
	@Input({ required: true }) public player: ICreatablePlayer;
}
