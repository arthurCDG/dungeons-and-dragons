import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAttackPayload, IHero, IMonster } from '../models/players.models';
import { ATTACK_HEROES_URL, ATTACK_MONSTERS_URL, DEV_BACKEND_URL } from './_api.urls';

@Injectable()
export class AttacksService {

	constructor(private readonly httpClient: HttpClient) {}

	public attackHeroAsync(heroId: number, payload: IAttackPayload): Observable<IHero> {
		return this.httpClient.post<IHero>(`${DEV_BACKEND_URL}/${ATTACK_HEROES_URL}/${heroId}`, payload);
	}

	public attackMonsterAsync(monsterId: number, payload: IAttackPayload): Observable<IMonster> {
		return this.httpClient.post<IMonster>(`${DEV_BACKEND_URL}/${ATTACK_MONSTERS_URL}/${monsterId}`, payload);
	}
}
