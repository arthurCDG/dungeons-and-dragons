import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { filter, map, startWith } from 'rxjs';

import { SessionStore } from '../../stores';

@Component({
    selector: 'app-header',
    imports: [CommonModule, RouterModule],
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})

export class HeaderComponent {
	protected readonly sessionStore = inject(SessionStore);
	private readonly router = inject(Router);

	protected readonly isAuthPage = toSignal(
		this.router.events.pipe(
			filter((event): event is NavigationEnd => event instanceof NavigationEnd),
			map(event => this.isAuthUrl(event.urlAfterRedirects)),
			startWith(this.isAuthUrl(this.router.url))
		),
		{ initialValue: this.isAuthUrl(this.router.url) }
	);

	public onLogout(): void {
		void this.sessionStore.logoutToLogin();
	}

	private isAuthUrl(url: string): boolean {
		return url === '/login' || url === '/signup';
	}
}
