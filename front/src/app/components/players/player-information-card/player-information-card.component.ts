import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IPlayer } from 'src/app/models';

@Component({
    selector: 'app-player-information-card',
    imports: [CommonModule, RouterModule],
    templateUrl: './player-information-card.component.html',
    styleUrls: ['./player-information-card.component.css']
})
export class PlayerInformationCardComponent{
	@Input() player: IPlayer;
}
