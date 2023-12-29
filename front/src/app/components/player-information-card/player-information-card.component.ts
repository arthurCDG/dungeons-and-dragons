import { Component, Input, OnInit } from '@angular/core';
import { IPlayer } from 'src/app/models';

@Component({
  selector: 'app-player-information-card',
  templateUrl: './player-information-card.component.html',
  styleUrls: ['./player-information-card.component.css']
})
export class PlayerInformationCardComponent implements OnInit {
	@Input() player: IPlayer;

	constructor() { }

	ngOnInit(): void {
	}

}
