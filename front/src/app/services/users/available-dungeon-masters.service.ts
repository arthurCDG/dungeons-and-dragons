import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DEV_BACKEND_URL } from '../_api.urls';
import { IUserDto } from '../../models';

@Injectable()
export class AvailableDungeonMastersService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(): Observable<IUserDto[]> {
		return this.httpClient.get<IUserDto[]>(`${DEV_BACKEND_URL}/api/available-dungeon-masters`);
	}

	public markAsAvailableAsync(userId: number): Observable<void> {
		return this.httpClient.post<void>(`${DEV_BACKEND_URL}/api/available-dungeon-masters`, { userId });
	}

	public markAsUnavailableAsync(userId: number): Observable<void> {
		return this.httpClient.delete<void>(`${DEV_BACKEND_URL}/api/available-dungeon-masters/${userId}`);
	}
}
