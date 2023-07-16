import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICampaign, ICampaignPayload } from '../models/campaign.models';
import { PLAYERS_URL, CAMPAIGNS_URL, DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class CampaignsService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(playerId: number): Observable<ICampaign[]> {
		return this.httpClient.get<ICampaign[]>(`${DEV_BACKEND_URL}/api/${CAMPAIGNS_URL}?playerId=${playerId}`);
	}
	
	public getByIdAsync(campaignId: number): Observable<ICampaign> {
		return this.httpClient.get<ICampaign>(`${DEV_BACKEND_URL}/api/${CAMPAIGNS_URL}/${campaignId}`);
	}

	public postAsync(payload: ICampaignPayload): Observable<void> {
		return this.httpClient.post<void>(`${DEV_BACKEND_URL}/api/${CAMPAIGNS_URL}`, payload);
	}
}
