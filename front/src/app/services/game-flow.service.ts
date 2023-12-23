import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICurrentPlayerDto } from './../models';
import { DEV_BACKEND_URL } from './_api.urls';

const BASE_URL = `${DEV_BACKEND_URL}/services/adventures`;

@Injectable()
export class GameFlowService {

	constructor(private readonly httpClient: HttpClient) {}

	public getCurrentPlayer(adventureId: number): Observable<ICurrentPlayerDto> {
		return this.httpClient.get<ICurrentPlayerDto>(`${BASE_URL}/${adventureId}/current-player`);
	}

	public setNextCurrentPlayer(adventureId: number): Observable<ICurrentPlayerDto> {
		return this.httpClient.get<ICurrentPlayerDto>(`${BASE_URL}/${adventureId}/next-player`);
	}

	public enableCurrentPlayer(adventureId: number): Observable<void> {
		return this.httpClient.post<void>(`${BASE_URL}/${adventureId}/enable-current-player`, null);
	}
}
