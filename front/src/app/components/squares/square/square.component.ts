import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';

import { ISquare } from '../../../models';
import { AdventureStore } from '../../../stores';
import { PlayerComponent } from '../../players/player/player.component';
import { DecorativeElementComponent } from '../decorative-element/decorative-element.component';
import { InteractiveElementComponent } from '../interactive-element/interactive-element.component';

@Component({
    selector: 'app-square',
    imports: [CommonModule, PlayerComponent, InteractiveElementComponent, DecorativeElementComponent],
    templateUrl: './square.component.html',
    styleUrls: ['./square.component.css']
})
export class SquareComponent implements OnInit {
	@Input({ required: true }) square!: ISquare;

	public readonly adventureStore = inject(AdventureStore);
	public tileStyle: string;

	ngOnInit(): void {
		const randomNumber: number = Math.ceil((Math.random() * 3));
		this.tileStyle = `type-${randomNumber}`;
	}

	public onSquareClicked(): void {
		void this.adventureStore.handleSquareClick(this.square);
	}

	public get isSelected(): boolean {
		return this.adventureStore.selectedSquareId() === this.square.id;
	}
}
