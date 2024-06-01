import { Injectable } from '@angular/core';
import { filter, Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EventsService {
	private eventService$ = new Subject<EventKey>();

	public listen(event: EventKey[]): Observable<EventKey> {
		return this.eventService$
			.asObservable()
			.pipe(filter(e => event.includes(e)));
	}

	public send(event: EventKey): void {
		this.eventService$.next(event);
	}
}

export type EventKey = 'IS_LOGGED_IN' | 'IS_LOGGED_OUT';