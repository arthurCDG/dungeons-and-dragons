import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAttackPayload, IPlayer } from '../models/players.models';
import { ATTACK_SERVICE_URL, DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class AttacksService {

	constructor(private readonly httpClient: HttpClient) {}

	public attackPlayerAsync(playerId: number, payload: IAttackPayload): Observable<IPlayer> {
		return this.httpClient.post<IPlayer>(`${DEV_BACKEND_URL}/${ATTACK_SERVICE_URL}/${playerId}`, payload);
	}
}
