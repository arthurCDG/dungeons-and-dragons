import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import {
	BackArrowComponent,
	CreatablePlayerClassCardComponent,
	CreatablePlayerSpeciesCardComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	SelectedPlayerComponent
} from '../../../components';
import { Class, ICreatablePlayer, ICreatableSpecies, IPlayerCreationPayload, PlayerGender, Species } from '../../../models';
import { CreatablePlayersService, PlayersService } from '../../../services';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { IFormRadioInput, playerCreationFormStep } from './models';

@Component({
	selector: 'app-player-creation-page',
	standalone: true,
	imports: [
		CommonModule,
		CreatablePlayerClassCardComponent,
		CreatablePlayerSpeciesCardComponent,
		SelectedPlayerComponent,
		PageWrapperComponent,
		PageBackgroundImageComponent,
		BackArrowComponent,
		ReactiveFormsModule
	],
	templateUrl: './player-creation-page.component.html',
	styleUrls: ['./player-creation-page.component.css'],
	providers: [
		PlayersService,
		CreatablePlayersService
	]
})
export class PlayerCreationPageComponent implements OnInit {
	private userId: number;

	public creatablePlayers: ICreatablePlayer[] = [];
	public associatedSpecies: ICreatableSpecies[] | undefined;
	public selectedClass?: Class;
	public selectedSpecies?: Species;
	public isLoading: boolean = true;

	public formStep: playerCreationFormStep = 'playerClass';

	public playerClassFieldName: string = 'playerClass';
	public playerClassOptions: IFormRadioInput[] = [
		{
			altText: 'Warrior class option',
			iconUrl: '../../../assets/icons/classes/warrior-class-icon.png',
			name: 'Guerrier',
			value: Class.Warrior
		},
		{
			altText: 'Rogue class option',
			iconUrl: '../../../assets/icons/classes/rogue-class-icon.png',
			name: 'Voleur',
			value: Class.Rogue
		},
		{
			altText: 'Cleric class option',
			iconUrl: '../../../assets/icons/classes/cleric-class-icon.png',
			name: 'Clerc',
			value: Class.Cleric
		},
		{
			altText: 'Wizard class option',
			iconUrl: '../../../assets/icons/classes/wizard-class-icon.png',
			name: 'Magicien',
			value: Class.Wizard
		}
	];

	public playerSpeciesFieldName: string = 'playerSpecies';
	public playerSpeciesOptions: IFormRadioInput[] = [
		{
			altText: 'Human species option',
			iconUrl: '../../../assets/icons/species/human-species-icon.svg',
			name: 'Humain',
			value: Species.Human
		},
		{
			altText: 'Elf species option',
			iconUrl: '../../../assets/icons/species/elf-species-icon.svg',
			name: 'Elfe',
			value: Species.Elf
		},
		{
			altText: 'Halfling species option',
			iconUrl: '../../../assets/icons/species/halfling-species-icon.svg',
			name: 'Halfelin',
			value: Species.Halfling
		},
		{
			altText: 'Dwarf species option',
			iconUrl: '../../../assets/icons/species/dwarf-species-icon.svg',
			name: 'Nain',
			value: Species.Dwarf
		}
	];

	public playerGenderFieldName: string = 'playerGender';
	public playerGenderOptions: IFormRadioInput[] = [
		{
			altText: 'Female-gender',
			iconUrl: '../../../assets/icons/genders/female-gender-icon.svg',
			name: 'Femme',
			value: PlayerGender.Female
		},
		{
			altText: 'Male-gender',
			iconUrl: '../../../assets/icons/genders/male-gender-icon.svg',
			name: 'Homme',
			value: PlayerGender.Male
		},
		{
			altText: 'Non-binary-gender',
			iconUrl: '../../../assets/icons/genders/non-binary-gender-icon.svg',
			name: 'Non binaire',
			value: PlayerGender.NonBinary
		}
	];
	
	classCtrl = this.fb.control<Class | null>(null);
	speciesCtrl = this.fb.control<Species | null>(null);
	genderCtrl = this.fb.control<PlayerGender>(PlayerGender.Female);
	nameCtrl = this.fb.control<string | null>(null);

	public playerCreationForm = this.fb.group({
		playerClass: this.classCtrl,
		playerSpecies: this.speciesCtrl,
		playerGender: this.genderCtrl,
		playerName: this.nameCtrl
	});

	constructor(
		private readonly playersService: PlayersService,
		private readonly creatablePlayersService: CreatablePlayersService,
		private readonly router: Router,
		private readonly activatedRoute: ActivatedRoute,
		private readonly fb: FormBuilder
	) {	}
	
	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.userId = Number(params['userId']));

		this.creatablePlayersService.getAsync(this.userId).subscribe(creatablePlayers => {
			this.creatablePlayers = creatablePlayers;
			if (this.creatablePlayers.length) {
				this.classCtrl.setValue(this.creatablePlayers[0].class.type);
				this.associatedSpecies = this.creatablePlayers[0].associatedSpecies;
				this.speciesCtrl.setValue(this.associatedSpecies[0].type);
			}

			this.isLoading = false;
		});

	}

	onSubmit(): void {
		// TODO: validate all required fields are filled

		const payload: IPlayerCreationPayload = {
			class: this.classCtrl.value!,
			name: this.nameCtrl.value!,
			gender: this.genderCtrl.value!,
			species: this.speciesCtrl.value!!
		};

		console.log(payload);

		this.playersService
			.createAsync(this.userId, payload)
			.subscribe(() => this.router.navigate(['..'], { relativeTo: this.activatedRoute }));
	}
}