import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IHero } from './../../../app/models/players.models';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.css']
})
export class HeroComponent implements OnInit {
	@Input() hero: IHero;

	constructor() {}

	ngOnInit(): void {}

}
