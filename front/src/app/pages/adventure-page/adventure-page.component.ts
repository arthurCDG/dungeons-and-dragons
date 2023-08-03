import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
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
	
	private campaignId: number;
	private adventureId: number;

	constructor(private readonly adventuresService: AdventuresService, private readonly activatedRoute: ActivatedRoute) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => {
			this.campaignId = Number(params['campaignId']);
			this.adventureId = Number(params['adventureId']);
		});

		this.adventuresService.getByIdAsync(this.campaignId, this.adventureId).subscribe((adventure: IAdventure) => {
				console.log('passing here ?? Adventure ==>', adventure);
				this.adventure = adventure;
				this.squares = adventure.squares;
		});

		// this.adventuresService.startAsync(1, 1) // TODO use in a different case (when coming from campaign component for the first time - maybe a specific button ?)
	}

	onSquareChanged(formerSquaredId: number): void {
		this.squaredIdThatNeedsToReload = formerSquaredId;
	}

	onSquareSelected(squareId: number): void {
		this.selectedSquaredId = squareId;
	}
}
