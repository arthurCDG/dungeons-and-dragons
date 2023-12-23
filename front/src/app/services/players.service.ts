import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPlayer, IPlayerCreationPayload } from '../models';
import { DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class PlayersService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync = (userId: number): Observable<IPlayer[]> =>
		this.httpClient.get<IPlayer[]>(`${DEV_BACKEND_URL}/api/users/${userId}/players`);

	public getByIdAsync = (userId: number, playerId: number): Observable<IPlayer> =>
		this.httpClient.get<IPlayer>(`${DEV_BACKEND_URL}/api/users/${userId}/players/${playerId}`);

	public createAsync = (userId: number, playerCreationPayload: IPlayerCreationPayload): Observable<IPlayer> =>
		this.httpClient.post<IPlayer>(`${DEV_BACKEND_URL}/api/users/${userId}/players`, playerCreationPayload);
}
