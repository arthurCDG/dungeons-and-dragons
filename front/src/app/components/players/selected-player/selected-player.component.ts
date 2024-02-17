import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Class } from '../../../models';

@Component({
  selector: 'app-selected-player',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './selected-player.component.html',
  styleUrls: ['./selected-player.component.css']
})
export class SelectedPlayerComponent {
	// TODO should be directly pictureUrl's value (not scalable like this)
	@Input() class: Class;
}
