import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IHero } from './../../../app/models/players.models';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.css']
})
export class HeroComponent implements OnInit, OnChanges {
	@Input() hero: IHero;

	public isDead: boolean;

	constructor() {}

	ngOnInit(): void {
		this.isDead = this.hero?.isDead;
	}

	ngOnChanges(): void {
		this.isDead = this.hero?.isDead;
	}
}
