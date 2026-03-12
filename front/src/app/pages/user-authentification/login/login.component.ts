import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ILoginPayload } from '../../../models';
import { BackArrowComponent, ToastMessageComponent, PageBackgroundImageComponent, ImageType, PageWrapperComponent } from '../../../../app/components';
import { SessionStore } from '../../../stores';

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
	styleUrls: ['./../styles/authentication.component.css']
})
export class LoginComponent {
	protected readonly sessionStore = inject(SessionStore);
	public backgroundImage: ImageType = 'signup-login-page';

	usernameCtrl = this.fb.control('');
	passwordCtrl = this.fb.control('');
	
	userForm = this.fb.group({
		username: this.usernameCtrl,
		password: this.passwordCtrl
	});
	
	constructor(
		private readonly fb: FormBuilder
	) { }

	public login(): void {
		const loginPayload: ILoginPayload = {
			userName: this.usernameCtrl.value!,
			password: this.passwordCtrl.value!
		};

		void this.sessionStore.login(loginPayload);
	}
}
