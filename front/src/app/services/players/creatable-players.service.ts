import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DEV_BACKEND_URL } from '../_api.urls';
import { ICreatablePlayer } from '../../models';

@Injectable()
export class CreatablePlayersService {
	constructor(private readonly httpClient: HttpClient) {}

	public getAsync(userId: number): Observable<ICreatablePlayer[]> {
		return this.httpClient.get<ICreatablePlayer[]>(`${DEV_BACKEND_URL}/service/users/${userId}/creatable-players`);
	}
}
