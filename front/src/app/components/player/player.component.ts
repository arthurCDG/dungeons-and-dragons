import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IPlayer } from 'src/app/models';

@Component({
  selector: 'app-player',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit, OnChanges {
	@Input() player: IPlayer;
	
	public isDead: boolean;

	constructor() {}

	ngOnInit(): void {
		this.isDead = this.player?.isDead;
	}

	ngOnChanges(): void {
		this.isDead = this.player?.isDead;
	}
}
