import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-empty-state-body',
  standalone: true,
  templateUrl: './empty-state-body.component.html',
  styleUrl: './empty-state-body.component.css'
})
export class EmptyStateBodyComponent {
	@Input() public title: string;
	@Input() public description: string;
}
