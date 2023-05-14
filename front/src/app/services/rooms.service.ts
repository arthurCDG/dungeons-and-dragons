import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRoom } from '../models/campaign.models';
import { CAMPAIGNS_URL, DEV_BACKEND_URL, ROOMS_URL, SESSIONS_URL } from './_api.urls';

@Injectable()
export class RoomsService {

	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(sessionId: number, campaignId: number): Observable<IRoom[]> {
		return this.httpClient.get<IRoom[]>(
			`${DEV_BACKEND_URL}/${SESSIONS_URL}/${sessionId}/${CAMPAIGNS_URL}/${campaignId}/${ROOMS_URL}`
		);
	}
}
