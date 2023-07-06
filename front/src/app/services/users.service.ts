import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUserDto, IUserPayload } from '../models/users.models';
import { DEV_BACKEND_URL } from './_api.urls';

const API_URL: string = 'api/users';

@Injectable()
export class UsersService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(): Observable<IUserDto[]> {
		return this.httpClient
			.get<IUserDto[]>(`${DEV_BACKEND_URL}/${API_URL}`);
	}

	public getByIdAsync(userId: number): Observable<IUserDto> {
		return this.httpClient
			.get<IUserDto>(`${DEV_BACKEND_URL}/${API_URL}/${userId}`);
	}

	public createAsync(userPayload: IUserPayload): Observable<IUserDto> {
		return this.httpClient
			.post<IUserDto>(`${DEV_BACKEND_URL}/${API_URL}`, userPayload);
	}
}
