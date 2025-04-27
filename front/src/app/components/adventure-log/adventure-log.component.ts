import { Component, inject, Input, OnInit } from '@angular/core';
import { AdventureLogService } from './adventure-log.service';

@Component({
    selector: 'app-adventure-log',
    imports: [],
    providers: [AdventureLogService],
    templateUrl: './adventure-log.component.html',
    styleUrl: './adventure-log.component.css'
})
export class AdventureLogComponent implements OnInit {
	adventureLogService = inject(AdventureLogService);
	logs: string[] = [];

	ngOnInit() {
		this.adventureLogService.logs$.subscribe(logs => {
		  this.logs = logs;
		});
	  }
}
