import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPlayer } from '../models/players.models';
import { DEV_BACKEND_URL, SQUARES_URL } from './_api.urls';
import { ISquare } from '../models/campaign.models';

@Injectable()
export class SquaresService {

	constructor(private readonly httpClient: HttpClient) {}

	public getAllAsync = (campaignId: number): Observable<ISquare[]> =>
		this.httpClient.get<ISquare[]>(`${DEV_BACKEND_URL}/${SQUARES_URL}/campaign/${campaignId}`);

	public getByIdAsync = (squareId: number): Observable<ISquare> =>
		this.httpClient.get<ISquare>(`${DEV_BACKEND_URL}/${SQUARES_URL}/${squareId}`);

	public getPlayerIfAnyAsync = (squareId: number): Observable<IPlayer> =>
		this.httpClient.get<IPlayer>(`${DEV_BACKEND_URL}/${SQUARES_URL}/${squareId}/player`);
}
