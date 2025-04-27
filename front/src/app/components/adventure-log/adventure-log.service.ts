import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AdventureLogService {
	private logsSubject = new BehaviorSubject<string[]>([]);
	logs$ = this.logsSubject.asObservable();

	addLog(log: string) {
		const currentLogs = this.logsSubject.value;
		this.logsSubject.next([...currentLogs, log]);
	}
}