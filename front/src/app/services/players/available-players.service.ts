import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DEV_BACKEND_URL } from '../_api.urls';
import { IAvailablePlayer } from '../../models';

@Injectable()
export class AvailablePlayersService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(): Observable<IAvailablePlayer[]> {
		return this.httpClient.get<IAvailablePlayer[]>(`${DEV_BACKEND_URL}/api/available-players`);
	}
}
