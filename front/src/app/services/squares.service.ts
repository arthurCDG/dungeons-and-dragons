import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DEV_BACKEND_URL, SQUARES_URL } from './_api.urls';
import { IPlayer } from '../models/players.models';

@Injectable()
export class SquaresService {

	constructor(private readonly httpClient: HttpClient) {}

	public getByIdAsync(squareId: number): Observable<IPlayer> {
		return this.httpClient.get<IPlayer>(`${DEV_BACKEND_URL}/${SQUARES_URL}/${squareId}`);
	}
}
