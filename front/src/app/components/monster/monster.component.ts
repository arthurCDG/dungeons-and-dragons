import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IMonster, MonsterType } from './../../../app/models/players.models';

@Component({
  selector: 'app-monster',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './monster.component.html',
  styleUrls: ['./monster.component.css']
})
export class MonsterComponent implements OnInit, OnChanges {
	@Input() monster: IMonster;

	public BugBear: MonsterType.BugBear;
	public Gnoll: MonsterType.Gnoll;
	public Goblin: MonsterType.Goblin;

	public isDead: boolean;

	constructor() {}

	ngOnInit(): void {
		this.isDead = this.monster?.isDead;
	}

	ngOnChanges(): void {
		this.isDead = this.monster?.isDead;
	}
}
