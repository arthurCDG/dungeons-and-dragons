import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AuthService } from '../../services';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-welcome-page',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css'],
  providers: [AuthService]
})
export class WelcomePageComponent {
	public isLoggedIn: boolean = false;
	public userId: number | null = null;

	constructor(private readonly authService: AuthService) { }

	ngOnInit(): void {
		this.authService.isLoggedIn$()
						.subscribe(isLoggedIn => this.isLoggedIn = isLoggedIn);

		this.authService.getCurrentUserId()
						.subscribe((userId: number | null) => this.userId = userId);
	}
}
