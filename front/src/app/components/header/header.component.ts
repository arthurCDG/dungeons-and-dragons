import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IUserDto } from '../../models/users.models';
import { AuthService } from '../../services';

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
	public user: IUserDto | undefined;

	constructor(private readonly authService: AuthService) { }

	ngOnInit(): void {
		this.authService.isLoggedIn$().subscribe(isLoggedIn => this.isLoggedIn = isLoggedIn);

		if (this.isLoggedIn)
		{
			this.authService.getCurrentUser().subscribe((user: IUserDto | undefined) => this.user = user);
		}
	}

	public onLogout(): void {
		this.authService.doLogoutAndRedirectToLogin();
	}
}
