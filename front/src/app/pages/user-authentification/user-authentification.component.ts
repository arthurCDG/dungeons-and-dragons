import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { shareReplay } from 'rxjs';
import { ILoginPayload, IUserPayload } from '../../models/users.models';
import { AuthService } from '../../services';

@Component({
  selector: 'app-user-authentification',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './user-authentification.component.html',
  styleUrls: ['./user-authentification.component.css'],
  providers: [AuthService]
})
export class UserAuthentificationComponent {
	usernameCtrl = this.fb.control('', [Validators.required, Validators.minLength(3)]);
	passwordCtrl = this.fb.control('', [Validators.required, Validators.minLength(6)]);
	
	userForm = this.fb.group({
		username: this.usernameCtrl,
		password: this.passwordCtrl
	});
	
	constructor(
		private readonly fb: FormBuilder,
		private readonly authService: AuthService,
		private readonly router: Router
	) {}

	public signup(): void {
		const userPayload: IUserPayload = {
			userName: this.usernameCtrl.value!,
			password: this.passwordCtrl.value!
		};

		this.authService.signupAsync(userPayload)
			.pipe(shareReplay())
			.subscribe((token: string | undefined) => {
				if (token !== undefined)
				{
					this.authService.doLoginUser(token);
					this .router.navigate(['..']);
				}
			})
	}

	public login(): void {
		const loginPayload: ILoginPayload = {
			userName: this.usernameCtrl.value!,
			password: this.passwordCtrl.value!
		};

		this.authService.loginAsync(loginPayload)
			.pipe(shareReplay())
			.subscribe((token: string | undefined) => {
				if (token !== undefined)
				{
					this.authService.doLoginUser(token);
					this .router.navigate(['..']);
				}
			})
	}
}
