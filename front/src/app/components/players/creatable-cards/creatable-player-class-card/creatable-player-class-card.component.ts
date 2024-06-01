import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Class, ICreatableClass } from '../../../../models';

@Component({
  selector: 'app-creatable-player-class-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './creatable-player-class-card.component.html',
  styleUrl: './../creatable-player-card-common-styles.css'
})
export class CreatablePlayerClassCardComponent {
	@Input() public class: ICreatableClass;
	@Input() public isSelectedClass: boolean;

	@Output() classSelected = new EventEmitter<Class>();

	public onSelectedClass(): void {
		this.classSelected.emit(this.class.type);
	}
}
