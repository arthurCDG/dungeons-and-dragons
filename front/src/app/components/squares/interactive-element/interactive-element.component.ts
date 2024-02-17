import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-interactive-element',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './interactive-element.component.html',
  styleUrls: ['./interactive-element.component.css']
})
export class InteractiveElementComponent {
	@Input() interactiveElement: InteractiveElementType;
}

export type InteractiveElementType = 'locked-chest' | 'door'; // Add more interactive elements
