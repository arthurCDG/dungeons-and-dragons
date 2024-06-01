import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICreatableSpecies, Species } from 'src/app/models';

@Component({
	selector: 'app-creatable-player-species-card',
	standalone: true,
	templateUrl: './creatable-player-species-card.component.html',
	styleUrl: './../creatable-player-card-common-styles.css'
})
export class CreatablePlayerSpeciesCardComponent {
	@Input({ required: true}) public species: ICreatableSpecies;
	@Input() public isSelectedSpecies: boolean;

	@Output() speciesSelected = new EventEmitter<Species>();

	ngOnInit(): void {
		console.log(this.species);
		console.log(this.species.type);
	}

	public onSelectedSpecies(): void {
		this.speciesSelected.emit(this.species.type);
	}
}
