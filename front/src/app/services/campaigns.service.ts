import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICampaign, ICampaignPayload } from '../models/campaign.models';
import { CAMPAIGNS_URL, DEV_BACKEND_URL, SESSIONS_URL } from './_api.urls';

@Injectable()
export class CampaignsService {

	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(sessionId: number, campaignId: number): Observable<ICampaign> {
		return this.httpClient.get<ICampaign>(`${DEV_BACKEND_URL}/${SESSIONS_URL}/${sessionId}/${CAMPAIGNS_URL}/${campaignId}`);
	}

	public postAsync(sessionId: number, payload: ICampaignPayload): Observable<void> {
		return this.httpClient.post<void>(`${DEV_BACKEND_URL}/${SESSIONS_URL}/${sessionId}/${CAMPAIGNS_URL}`, payload);
	}
}
