import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IMonster } from './../../../app/models/players.models';

@Component({
  selector: 'app-monster',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './monster.component.html',
  styleUrls: ['./monster.component.css']
})
export class MonsterComponent implements OnInit {
	@Input() monster: IMonster;

	constructor(private cdr: ChangeDetectorRef) { }

	ngOnInit(): void {
		console.log('this.monster', this.monster);
		this.cdr.markForCheck();
	}

}
