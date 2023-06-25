import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ActionBarComponent } from '../../components/action-bar/action-bar.component';
import { IAdventure, ISquare } from '../../models';
import { AdventuresService } from '../../services/adventures.service';
import { SquareComponent } from 'src/app/components/square/square.component';

@Component({
  selector: 'app-adventure-page',
  standalone: true,
  imports: [CommonModule, RouterModule, ActionBarComponent, SquareComponent],
  templateUrl: './adventure-page.component.html',
  styleUrls: ['./adventure-page.component.css'],
  providers: [AdventuresService]
})
export class AdventurePageComponent implements OnInit {
	public adventure: IAdventure;
	public squares: ISquare[];

	public squaredIdThatNeedsToReload: number;
	public selectedSquaredId: number;
	
	constructor(private readonly adventuresService: AdventuresService) { }

	ngOnInit(): void {
		this.adventuresService.getByIdAsync(1, 1) // TODO retrieve from params service
		// this.adventuresService.startAsync(1, 1) // TODO use in a different case (when coming from campaign component for the first time - maybe a specific button ?)
			.subscribe((adventure: IAdventure) => {
				console.log('passing here ?? Adventure ==>', adventure);
				
				this.adventure = adventure;
				this.squares = adventure.squares;
			});
	}

	onSquareChanged(formerSquaredId: number): void {
		this.squaredIdThatNeedsToReload = formerSquaredId;
	}

	onSquareSelected(squareId: number): void {
		this.selectedSquaredId = squareId;
	}
}
