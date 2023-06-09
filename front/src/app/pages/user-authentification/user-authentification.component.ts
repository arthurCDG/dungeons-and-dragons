import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsersService } from '../../services';
import { IUserPayload } from 'src/app/models/users.models';

@Component({
  selector: 'app-user-authentification',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './user-authentification.component.html',
  styleUrls: ['./user-authentification.component.css'],
  providers: [UsersService]
})
export class UserAuthentificationComponent {
	usernameCtrl = this.fb.control('', [Validators.required, Validators.minLength(3)]);
	passwordCtrl = this.fb.control('', [Validators.required, Validators.minLength(6)]);
	
	userForm = this.fb.group({
		username: this.usernameCtrl,
		password: this.passwordCtrl
	});
	
	constructor(private readonly fb: FormBuilder, private readonly usersService: UsersService) {}

	register(): void {
		const payload: IUserPayload = {
			name: this.usernameCtrl.value!,
			password: this.passwordCtrl.value!
		};

		this.usersService.createAsync(payload).subscribe(user => console.log('User created!', user));
	}
}
