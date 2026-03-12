import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SessionStore } from '../../stores';

@Component({
    selector: 'app-welcome-page',
    imports: [CommonModule, RouterModule],
    templateUrl: './welcome-page.component.html',
    styleUrls: ['./welcome-page.component.css']
})
export class WelcomePageComponent {
	protected readonly sessionStore = inject(SessionStore);
}
