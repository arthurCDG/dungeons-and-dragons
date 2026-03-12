import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { IUserPayload } from '../../../models/users.models';
import { confirmPasswordValidator } from '../validators/confirm-password.validator';
import { BackArrowComponent, ToastMessageComponent, PageBackgroundImageComponent, ImageType, PageWrapperComponent } from '../../../../app/components';
import { SessionStore } from '../../../stores';

@Component({
    selector: 'app-sign-up',
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        ToastMessageComponent,
        BackArrowComponent,
        PageWrapperComponent,
        PageBackgroundImageComponent
    ],
    templateUrl: './sign-up.component.html',
	styleUrls: ['./../styles/authentication.component.css']
})
export class SignupComponent {
	protected readonly sessionStore = inject(SessionStore);
	public backgroundImage: ImageType = 'signup-login-page';

	usernameCtrl = this.fb.control('', [Validators.required, Validators.minLength(3)]);
	passwordCtrl = this.fb.control('', [Validators.required, Validators.minLength(6)]);
	confirmedPasswordCtrl = this.fb.control('', [Validators.required, Validators.minLength(6), confirmPasswordValidator]);
	
	userForm = this.fb.group({
		username: this.usernameCtrl,
		password: this.passwordCtrl,
		confirmedPassword: this.confirmedPasswordCtrl
	});
	
	constructor(
		private readonly fb: FormBuilder
	) {}

	public signup(): void {
		const userPayload: IUserPayload = {
			userName: this.usernameCtrl.value!,
			password: this.passwordCtrl.value!
		};

		void this.sessionStore.signup(userPayload);
	}
}
