import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStoredItem } from './../../models';
import { DEV_BACKEND_URL } from './../_api.urls';

const BASE_URL = `${DEV_BACKEND_URL}/services/chest-items`;

@Injectable()
export class ChestItemsService {

	constructor(private readonly httpClient: HttpClient) {}

	public get(playerId: number): Observable<IStoredItem> {
		return this.httpClient.get<IStoredItem>(`${BASE_URL}?playerId=${playerId}`);
	}
}
