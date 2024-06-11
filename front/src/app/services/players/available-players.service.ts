import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DEV_BACKEND_URL } from '../_api.urls';
import { IPlayer } from '../../models';

@Injectable()
export class AvailablePlayersService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(): Observable<IPlayer[]> {
		return this.httpClient.get<IPlayer[]>(`${DEV_BACKEND_URL}/api/available-players`);
	}

	public markAsAvailableAsync(playerId: number): Observable<void> {
		return this.httpClient.post<void>(`${DEV_BACKEND_URL}/api/available-players`, playerId);
	}

	public markAsUnavailableAsync(playerId: number): Observable<void> {
		return this.httpClient.delete<void>(`${DEV_BACKEND_URL}/api/available-players/${playerId}`);
	}
}
