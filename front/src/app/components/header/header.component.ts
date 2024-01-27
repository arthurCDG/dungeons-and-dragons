import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IUserDto } from '../../models/users.models';
import { AuthService } from '../../services';
import { Observable, retry, takeUntil } from 'rxjs';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [AuthService]
})
export class HeaderComponent implements OnInit {
	public isLoggedIn = false;
	public isLoading = true;
	public userId: number | null = null;

	constructor(private readonly authService: AuthService) { }

	ngOnInit(): void {
		this.authService.isLoggedIn$().subscribe(isLoggedIn => this.isLoggedIn = isLoggedIn);
		this.authService.getCurrentUserId()
						.subscribe((userId: number | null) => {
							this.userId = userId;
							this.isLoading = false;
						});
	}

	public onLogout(): void {
		this.authService.doLogoutAndRedirectToLogin();
	}
}
