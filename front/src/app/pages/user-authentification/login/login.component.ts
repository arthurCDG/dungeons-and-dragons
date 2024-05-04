import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

import { catchError, shareReplay } from 'rxjs';
import { IAuthentifiedUser, ILoginPayload } from '../../../models';
import { AuthService } from '../../../services';
import { ToastMessageComponent } from '../../../components/toast-message/toast-message.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, ToastMessageComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./../styles/authentication.component.css'],
  providers: [AuthService]
})
export class LoginComponent implements OnInit {
	public httpError: HttpErrorResponse | null = null;

	usernameCtrl = this.fb.control('');
	passwordCtrl = this.fb.control('');
	
	userForm = this.fb.group({
		username: this.usernameCtrl,
		password: this.passwordCtrl
	});
	
	constructor(
		private readonly fb: FormBuilder,
		private readonly authService: AuthService,
		private readonly router: Router
	) { }

	ngOnInit(): void {
	}

	public login(): void {
		const loginPayload: ILoginPayload = {
			userName: this.usernameCtrl.value!,
			password: this.passwordCtrl.value!
		};

		this.authService.loginAsync(loginPayload)
			.pipe(
				shareReplay(),
				catchError(error => {
					this.httpError = error;
					throw error;
				}))
			.subscribe((authentifiedUser: IAuthentifiedUser | null) => {
				if (authentifiedUser)
				{
					this.authService.doLoginUser(authentifiedUser);
					this .router.navigate(['..']);
				}
			})
	}
}
