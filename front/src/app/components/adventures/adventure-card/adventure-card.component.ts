import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { IAdventure } from 'src/app/models';

@Component({
    selector: 'app-adventure-card',
    imports: [CommonModule, RouterModule],
    templateUrl: './adventure-card.component.html',
    styleUrls: ['./adventure-card.component.css']
})
export class AdventureCardComponent implements OnInit {
	@Input() adventure: IAdventure
	
	constructor() { }

	ngOnInit(): void { }
}
