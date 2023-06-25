import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICampaign, ICampaignPayload } from '../models/campaign.models';
import { PLAYERS_URL, CAMPAIGNS_URL, DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class CampaignsService {

	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(playerId: number, campaignId: number): Observable<ICampaign[]> {
		return this.httpClient.get<ICampaign[]>(`${DEV_BACKEND_URL}/${PLAYERS_URL}/${playerId}/${CAMPAIGNS_URL}`);
	}
	
	public getByIdAsync(playerId: number, campaignId: number): Observable<ICampaign> {
		return this.httpClient.get<ICampaign>(`${DEV_BACKEND_URL}/${PLAYERS_URL}/${playerId}/${CAMPAIGNS_URL}/${campaignId}`);
	}

	public postAsync(payload: ICampaignPayload): Observable<void> {
		return this.httpClient.post<void>(`${DEV_BACKEND_URL}/${CAMPAIGNS_URL}`, payload);
	}
}
