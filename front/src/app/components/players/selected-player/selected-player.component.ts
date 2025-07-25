import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Class, Species } from '../../../models';

// TODO : delete this component?
@Component({
    selector: 'app-selected-player',
    imports: [CommonModule],
    templateUrl: './selected-player.component.html',
    styleUrls: ['./selected-player.component.css']
})
export class SelectedPlayerComponent {
	// TODO should be directly pictureUrl's value (not scalable like this)
	@Input() selectedClass: Class;
	@Input() selectedSpecies: Species;
}
