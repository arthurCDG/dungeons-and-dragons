import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DEV_BACKEND_URL } from './_api.urls';
import { ICreatableCampaign } from '../models';

@Injectable()
export class CreatableCampaignsService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(playerId: number): Observable<ICreatableCampaign[]> {
		return this.httpClient.get<ICreatableCampaign[]>(`${DEV_BACKEND_URL}/services/players/${playerId}/creatable-campaigns`);
	}
}
