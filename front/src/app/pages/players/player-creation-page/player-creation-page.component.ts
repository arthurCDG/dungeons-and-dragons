import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatStepperModule } from '@angular/material/stepper';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError } from 'rxjs';

import {
	BackArrowComponent,
	LoadingSpinnerComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	SelectedPlayerComponent,
	ToastMessageComponent
} from '../../../components';
import { getLokalisedClassName, getLokalisedGenderName, getLokalisedSpeciesName } from '../../../helpers';
import { Class, ICreatablePlayer, IPlayerCreationPayload, PlayerGender, Species } from '../../../models';
import { CreatablePlayersService, PlayersService } from '../../../services';
import { IFormRadioInput } from './models';

@Component({
    selector: 'app-player-creation-page',
    imports: [
        CommonModule,
        SelectedPlayerComponent,
        PageWrapperComponent,
        PageBackgroundImageComponent,
        BackArrowComponent,
        ToastMessageComponent,
        LoadingSpinnerComponent,
        ReactiveFormsModule,
        MatStepperModule
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
	public creatableClasses: IFormRadioInput[] = [];
	public associatedSpecies: IFormRadioInput[] = [];
	public selectedClass?: Class;
	public selectedSpecies?: Species;
	public isLoading: boolean = true;

	public httpError: HttpErrorResponse | null = null;

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
	genderCtrl = this.fb.control<PlayerGender | null>(null);
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
			this.creatableClasses = creatablePlayers.map(cp => {
				return {
					altText: `${cp.class.lokalisedClassName} class option`,
					iconUrl: getIconUrlFromClass(cp.class.type),
					name: cp.class.lokalisedClassName,
					value: cp.class.type
				};
			});

			this.classCtrl.valueChanges.subscribe(classType => {
				this.associatedSpecies = this.creatablePlayers
					.filter(cp => cp.class.type === classType)
					.flatMap(cp => cp.associatedSpecies)
					.map(as => {
						return {
							altText: `${as.lokalisedSpeciesName} species option`,
							iconUrl: getIconUrlFromSpecies(as.type),
							name: as.lokalisedSpeciesName,
							value: as.type
						};
					});
			});

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

		this.playersService
			.createAsync(this.userId, payload)
			.pipe(
				catchError(error => {
					this.httpError = error;
					throw error;
				})
			)
			.subscribe(() => this.router.navigate(['..'], { relativeTo: this.activatedRoute }));
	}

	public getLokalisedClassName = (classType: Class): string => getLokalisedClassName(classType);
	public getLokalisedSpeciesName = (speciesType: Species): string => getLokalisedSpeciesName(speciesType);
	public getLokalisedGenderName = (gender: PlayerGender): string => getLokalisedGenderName(gender);
}

const getIconUrlFromClass = (type: Class): string => {
	switch (type) {
		case Class.Warrior:
			return '../../../assets/icons/classes/warrior-class-icon.png';
		case Class.Rogue:
			return '../../../assets/icons/classes/rogue-class-icon.png';
		case Class.Cleric:
			return '../../../assets/icons/classes/cleric-class-icon.png';
		case Class.Wizard:
		default:
			return '../../../assets/icons/classes/wizard-class-icon.png';
	}
}

const getIconUrlFromSpecies = (type: Species): string => {
	switch (type) {
		case Species.Human:
			return '../../../assets/icons/species/human-species-icon.svg';
		case Species.Elf:
			return '../../../assets/icons/species/elf-species-icon.svg';
		case Species.Halfling:
			return '../../../assets/icons/species/halfling-species-icon.svg';
		case Species.Dwarf:
		default:
			return '../../../assets/icons/species/dwarf-species-icon.svg';
	}
}