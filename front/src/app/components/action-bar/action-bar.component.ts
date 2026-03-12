import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';

import { AttackType } from '../../models/players.models';
import { AdventureStore } from '../../stores';

@Component({
    selector: 'app-action-bar',
    imports: [CommonModule],
    templateUrl: './action-bar.component.html',
    styleUrls: ['./action-bar.component.css']
})
export class ActionBarComponent {
	public readonly adventureStore = inject(AdventureStore);

	public onMeleeAttackAsync = (): void => void this.adventureStore.attackSelectedSquare(AttackType.Melee);
	public onRangedAttackAsync = (): void => void this.adventureStore.attackSelectedSquare(AttackType.Ranged);
	public onSpellAttackAsync = (): void => void this.adventureStore.attackSelectedSquare(AttackType.Spell);

	public onHealAsync(): void {
		// TODO
	}

	public onSearchAsync(): void {
		void this.adventureStore.searchChest();
	}

	public onOpenDoorAsync(): void {
		// TODO
	}

	public onEndTurnAsync(): void {
		void this.adventureStore.endTurn();
	}
}
