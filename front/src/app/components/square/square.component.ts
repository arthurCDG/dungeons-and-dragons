import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeroComponent } from '../hero/hero.component';
import { MonsterComponent } from '../monster/monster.component';
import { InteractiveElementComponent } from '../interactive-element/interactive-element.component';
import { ISquare } from 'src/app/models/campaign.models';

@Component({
  selector: 'app-square',
  standalone: true,
  imports: [CommonModule, HeroComponent, MonsterComponent, InteractiveElementComponent],
  templateUrl: './square.component.html',
  styleUrls: ['./square.component.css']
})
export class SquareComponent implements OnInit {
	@Input() square: ISquare;
	
	constructor() { }

	ngOnInit(): void {}
}
