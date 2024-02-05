import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { shareReplay } from 'rxjs';
import { IAuthentifiedUser, ILoginPayload } from '../../../models';
import { AuthService } from '../../../services';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './login.component.html',
  providers: [AuthService]
})
export class LoginComponent implements OnInit {
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
			.pipe(shareReplay())
			.subscribe((authentifiedUser: IAuthentifiedUser | null) => {
				if (authentifiedUser)
				{
					this.authService.doLoginUser(authentifiedUser);
					this .router.navigate(['..']);
				}
			})
	}
}
