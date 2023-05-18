import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AttacksService } from './../../../app/services';
import { IAttackPayload } from './../../../app/models/players.models';

@Component({
  selector: 'app-action-bar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './action-bar.component.html',
//   styleUrls: ['./action-bar.component.css'],
  providers: [AttacksService]
})
export class ActionBarComponent implements OnInit {
	constructor(private readonly attacksService: AttacksService) {}

	ngOnInit(): void {}

	onAttackAsync(): void {
		const monsterId = 17;
		const attack: IAttackPayload = {
			meleeAttack: 2
		};

		this.attacksService.attackMonsterAsync(monsterId, attack).subscribe(() => console.log('attacked'));
	}
}
