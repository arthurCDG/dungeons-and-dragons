import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { IAuthentifiedUser, ILoginPayload, IUserPayload } from '../models/users.models';
import { DEV_BACKEND_URL } from './_api.urls';

const API_URL: string = 'services/auth';

@Injectable()
export class AuthService {
	private readonly JWT_TOKEN = 'JWT_TOKEN';
	private readonly USER_ID = 'USER_ID';

	public INITIAL_PATH = ''; // TODO change ?

	constructor(
		private readonly httpClient: HttpClient,
		private readonly router: Router
	) {}

	public signupAsync = (userPayload: IUserPayload): Observable<IAuthentifiedUser | null> =>
		this.httpClient.post<IAuthentifiedUser | null>(`${DEV_BACKEND_URL}/${API_URL}/signup`, userPayload);

	public loginAsync = (loginPayload: ILoginPayload): Observable<IAuthentifiedUser | null> =>
		this.httpClient.post<IAuthentifiedUser | null>(`${DEV_BACKEND_URL}/${API_URL}/login`, loginPayload);

	public isLoggedIn$(): Observable<boolean> {
		return this.getToken() ? of(true) : of(false);
	}

	public doLoginUser = (authentifiedUser: IAuthentifiedUser): void => {
		localStorage.setItem(this.JWT_TOKEN, authentifiedUser.token);
		localStorage.setItem(this.USER_ID, authentifiedUser.userId.toString());
	}
	
	public doLogoutUser = (): void => {
		localStorage.removeItem(this.JWT_TOKEN);
		localStorage.removeItem(this.USER_ID);
	}

	public doLogoutAndRedirectToLogin = (): void => {
		this.doLogoutUser();
		this.router.navigate(['..']);
	}

	public getCurrentUserId(): Observable<number | null> {
		const userId: string | null = this.getLocalUserId();
		
		if (userId) {
			return of(Number.parseInt(userId));
		} else {
			return of(null);
		}
	}
	
	public getToken = (): string | null => localStorage.getItem(this.JWT_TOKEN);
	public getLocalUserId = (): string | null => localStorage.getItem(this.USER_ID);
}
