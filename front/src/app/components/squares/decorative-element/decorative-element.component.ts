import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-decorative-element',
    imports: [CommonModule],
    templateUrl: './decorative-element.component.html',
    styleUrls: ['./decorative-element.component.css']
})
export class DecorativeElementComponent {
	@Input() decorativeElement: DecorativeElementType
}

export type DecorativeElementType = 'pillar' | 'opened-chest'; // Add more decorative elements