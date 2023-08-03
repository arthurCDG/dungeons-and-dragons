import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreatableAdventure } from '../models';
import { DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class CreatableAdventuresService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(campaignId: number): Observable<ICreatableAdventure[]> {
		return this.httpClient.get<ICreatableAdventure[]>(`${DEV_BACKEND_URL}/services/campaigns/${campaignId}/creatable-adventures`);
	}
}
