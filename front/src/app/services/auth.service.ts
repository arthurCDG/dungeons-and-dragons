import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAuthentifiedUser, ILoginPayload, IUserPayload } from '../models/users.models';
import { DEV_BACKEND_URL } from './_api.urls';

const API_URL: string = 'services/auth';

@Injectable({ providedIn: 'root' })
export class AuthService {
	private readonly jwtTokenKey = 'JWT_TOKEN';
	private readonly userIdKey = 'USER_ID';

	constructor(private readonly httpClient: HttpClient) {}

	public signupAsync = (userPayload: IUserPayload): Observable<IAuthentifiedUser | null> =>
		this.httpClient.post<IAuthentifiedUser | null>(`${DEV_BACKEND_URL}/${API_URL}/signup`, userPayload);

	public loginAsync = (loginPayload: ILoginPayload): Observable<IAuthentifiedUser | null> =>
		this.httpClient.post<IAuthentifiedUser | null>(`${DEV_BACKEND_URL}/${API_URL}/login`, loginPayload);

	public storeSession(authentifiedUser: IAuthentifiedUser): void {
		localStorage.setItem(this.jwtTokenKey, authentifiedUser.token);
		localStorage.setItem(this.userIdKey, authentifiedUser.userId.toString());
	}
	
	public clearSession(): void {
		localStorage.removeItem(this.jwtTokenKey);
		localStorage.removeItem(this.userIdKey);
	}

	public readStoredSession(): StoredSession {
		const token = localStorage.getItem(this.jwtTokenKey);
		const userId = localStorage.getItem(this.userIdKey);

		return {
			token,
			userId: userId === null ? null : Number.parseInt(userId, 10)
		};
	}
	
	public getToken(): string | null {
		return localStorage.getItem(this.jwtTokenKey);
	}
}

export interface StoredSession {
	token: string | null;
	userId: number | null;
}
