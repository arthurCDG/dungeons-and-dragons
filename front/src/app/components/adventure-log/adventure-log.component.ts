import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';

import { AdventureStore } from '../../stores';

@Component({
    selector: 'app-adventure-log',
    imports: [CommonModule],
    templateUrl: './adventure-log.component.html',
    styleUrl: './adventure-log.component.css'
})
export class AdventureLogComponent {
	public readonly adventureStore = inject(AdventureStore);
}
