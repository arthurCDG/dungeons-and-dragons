import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AdventureType, IAdventure } from '../models/campaign.models';
import { ADVENTURES_URL, CAMPAIGNS_URL, DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class AdventuresService {

	constructor(private readonly httpClient: HttpClient) {}

	public getByIdAsync(campaignId: number, adventureId: number): Observable<IAdventure> {
		return this.httpClient
			.get<IAdventure>(`${DEV_BACKEND_URL}/api/${CAMPAIGNS_URL}/${campaignId}/${ADVENTURES_URL}/${adventureId}`);
	}

	public startAsync(campaignId: number, adventureType: AdventureType): Observable<IAdventure> {
		return this.httpClient
			.post<IAdventure>(`${DEV_BACKEND_URL}/api/${CAMPAIGNS_URL}/${campaignId}/${ADVENTURES_URL}`, adventureType);
	}
}
