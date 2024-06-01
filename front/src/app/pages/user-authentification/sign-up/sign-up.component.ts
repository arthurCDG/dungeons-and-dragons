import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { catchError, shareReplay } from 'rxjs';

import { IAuthentifiedUser, IUserPayload } from '../../../models/users.models';
import { AuthService, EventsService, UsersService } from '../../../services';
import { confirmPasswordValidator } from '../validators/confirm-password.validator';
import { ToastMessageComponent } from '../../../components/toast-message/toast-message.component';
import { BackArrowComponent } from 'src/app/components/back-arrow/back-arrow.component';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, ToastMessageComponent, BackArrowComponent],
  templateUrl: './sign-up.component.html',
  styleUrls: ['./../styles/authentication.component.css'],
  providers: [AuthService, UsersService]
})
export class SignupComponent {
	public httpError: HttpErrorResponse | null = null;

	usernameCtrl = this.fb.control('', [Validators.required, Validators.minLength(3)]);
	passwordCtrl = this.fb.control('', [Validators.required, Validators.minLength(6)]);
	confirmedPasswordCtrl = this.fb.control('', [Validators.required, Validators.minLength(6), confirmPasswordValidator]);
	
	userForm = this.fb.group({
		username: this.usernameCtrl,
		password: this.passwordCtrl,
		confirmedPassword: this.confirmedPasswordCtrl
	});
	
	constructor(
		private readonly fb: FormBuilder,
		private readonly authService: AuthService,
		private readonly router: Router,
		private readonly eventsService: EventsService
	) {}

	public signup(): void {
		const userPayload: IUserPayload = {
			userName: this.usernameCtrl.value!,
			password: this.passwordCtrl.value!
		};

		this.authService.signupAsync(userPayload)
			.pipe(
				shareReplay(),
				catchError(error => {
					this.httpError = error;
					throw error;
				})
			)
			.subscribe((authentifiedUser: IAuthentifiedUser | null) => {
				if (authentifiedUser) {
					this.authService.doLoginUser(authentifiedUser);
					this.eventsService.send('IS_LOGGED_IN');
					this.router.navigate(['users', authentifiedUser.userId, 'players']);
				}
			});
	}
}
