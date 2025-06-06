import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

import { catchError, shareReplay } from 'rxjs';
import { IAuthentifiedUser, ILoginPayload } from '../../../models';
import { AuthService, EventsService } from '../../../services';
import { BackArrowComponent, ToastMessageComponent, PageBackgroundImageComponent, ImageType, PageWrapperComponent } from '../../../../app/components';

@Component({
    selector: 'app-login',
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        ToastMessageComponent,
        BackArrowComponent,
        PageWrapperComponent,
        PageBackgroundImageComponent
    ],
    templateUrl: './login.component.html',
    styleUrls: ['./../styles/authentication.component.css'],
    providers: [AuthService]
})
export class LoginComponent {
	public httpError: HttpErrorResponse | null = null;
	public backgroundImage: ImageType = 'signup-login-page';

	usernameCtrl = this.fb.control('');
	passwordCtrl = this.fb.control('');
	
	userForm = this.fb.group({
		username: this.usernameCtrl,
		password: this.passwordCtrl
	});
	
	constructor(
		private readonly fb: FormBuilder,
		private readonly authService: AuthService,
		private readonly router: Router,
		private readonly eventsService: EventsService
	) { }

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
					this.eventsService.send('IS_LOGGED_IN');
					this.router.navigate(['users', authentifiedUser.userId, 'players']);
				}
			})
	}
}
