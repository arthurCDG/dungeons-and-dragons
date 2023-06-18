import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CAMPAIGNS_URL, DEV_BACKEND_URL } from './_api.urls';
import { ICurrentPlayerDto } from './../models';

const BASE_URL = `${DEV_BACKEND_URL}/api/${CAMPAIGNS_URL}`;

@Injectable()
export class GameFlowService {

	constructor(private readonly httpClient: HttpClient) {}

	public getCurrentPlayer(campaignId: number): Observable<ICurrentPlayerDto> {
		return this.httpClient.get<ICurrentPlayerDto>(`${BASE_URL}/${campaignId}/current-player`);
	}

	public getNextCurrentPlayer(campaignId: number): Observable<ICurrentPlayerDto> {
		return this.httpClient.get<ICurrentPlayerDto>(`${BASE_URL}/${campaignId}/next-player`);
	}

	public enableCurrentPlayer(campaignId: number): Observable<void> {
		return this.httpClient.post<void>(`${BASE_URL}/${campaignId}/enable-current-player`, null);
	}
}
