import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAdventure } from '../models/campaign.models';
import { CAMPAIGNS_URL, ADVENTURES_URL, DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class AdventuresService {

	constructor(private readonly httpClient: HttpClient) {}

	public startAsync(campaignId: number, adventureId: number): Observable<IAdventure> {
		return this.httpClient
			.get<IAdventure>(`${DEV_BACKEND_URL}/api/${CAMPAIGNS_URL}/${campaignId}/${ADVENTURES_URL}/${adventureId}`);
	}
}
