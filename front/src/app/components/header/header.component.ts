import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NavigationEnd, NavigationStart, Router, RouterModule } from '@angular/router';
import { Subscription, filter } from 'rxjs';
import { AuthService, EventsService } from '../../services';

@Component({
    selector: 'app-header',
    imports: [CommonModule, RouterModule],
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css'],
    providers: [AuthService]
})
export class HeaderComponent implements OnInit {
	public isLoggedIn = false;
	public isLoading = true;
	public userId: number | null = null;
	public isAuthPage = false;

	constructor(
		private readonly authService: AuthService,
		private readonly router: Router,
		private readonly eventsService: EventsService
	) {	}

	ngOnInit(): void {
		this.authService.isLoggedIn$()
						.subscribe(isLoggedIn => this.isLoggedIn = isLoggedIn);

		this.authService.getCurrentUserId()
						.subscribe((userId: number | null) => {
							this.userId = userId;
							this.isLoading = false;
						});

		this.router.events.pipe(filter((e): e is NavigationEnd => e instanceof NavigationStart || e instanceof NavigationEnd))
						  .subscribe((urlEvent: NavigationEnd) => {
							  this.isAuthPage = urlEvent.url === '/login' || urlEvent.url === '/signup';
						  });

		this.eventsService.listen(['IS_LOGGED_IN']).subscribe(() => this.isLoggedIn = true);
		this.eventsService.listen(['IS_LOGGED_OUT']).subscribe(() => this.isLoggedIn = false);

		if (this.isLoggedIn && this.userId != null) {
			this.router.navigate(['/users', this.userId, 'players']);
		}
	}

	public onLogout(): void {
		this.authService.doLogoutAndRedirectToLogin();
		this.userId = null;
		this.isLoggedIn = false;
	}
}
