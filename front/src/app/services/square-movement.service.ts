import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DEV_BACKEND_URL, SQUARE_MOVEMENT_URL } from './_api.urls';
import { IMovement, IMovementRequestPayload } from '../models/campaign.models';

@Injectable()
export class SquareMovementService {

	constructor(private readonly httpClient: HttpClient) {}

	public MoveToPositionAsync(payload: IMovementRequestPayload): Observable<IMovement> {
		return this.httpClient.post<IMovement>(`${DEV_BACKEND_URL}/${SQUARE_MOVEMENT_URL}`, payload);
	}
}
