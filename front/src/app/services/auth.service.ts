import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of } from 'rxjs';
import { ILoginPayload, IUserDto, IUserPayload } from '../models/users.models';
import { DEV_BACKEND_URL } from './_api.urls';
import { Router } from '@angular/router';

const API_URL: string = 'services/auth';

@Injectable()
export class AuthService {
	public INITIAL_PATH = ''; // TODO change ?

	constructor(private readonly httpClient: HttpClient, private readonly router: Router) {}

	public signupAsync = (userPayload: IUserPayload): Observable<string | undefined> =>
		this.httpClient.post<string | undefined>(`${DEV_BACKEND_URL}/${API_URL}/signup`, userPayload, { responseType: 'text' as 'json'});

	public loginAsync = (loginPayload: ILoginPayload): Observable<string | undefined> =>
		this.httpClient.post<string | undefined>(`${DEV_BACKEND_URL}/${API_URL}/login`, loginPayload, { responseType: 'text' as 'json'});

	public isLoggedIn$(): Observable<boolean> {
		return this.getCurrentUser().pipe(
		  map(user => !!user),
		  catchError(() => of(false))
		);
	}

	public doLoginUser = (token: string): void => localStorage.setItem(this.JWT_TOKEN, token);
	
	public doLogoutUser = (): void => localStorage.removeItem(this.JWT_TOKEN);

	public doLogoutAndRedirectToLogin = (): void => {
		this.doLogoutUser();
		this.router.navigate(['..']);
	}
	
	public getCurrentUser(): Observable<IUserDto | undefined> {
		const token = this.getToken();
		
		if (token) {
			const encodedPayload = token.split('.')[1];
			const payload = window.atob(encodedPayload);
			return of(JSON.parse(payload));
		} else {
			return of(undefined);
		}
	}
	
	public getToken = (): string | null => localStorage.getItem(this.JWT_TOKEN);
	
	private readonly JWT_TOKEN = 'JWT_TOKEN';
}
