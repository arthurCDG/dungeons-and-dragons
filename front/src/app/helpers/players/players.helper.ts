import { Class, PlayerGender, Species } from "../../models";

export const getLokalisedClassName = (classType: Class, gender: PlayerGender | null = null): string => {
	switch (classType) {
		case Class.Warrior:
			return gender === PlayerGender.Female? 'Guerrière' : 'Guerrier';
		case Class.Rogue:
			return gender === PlayerGender.Female? 'Voleuse' :  'Voleur';
		case Class.Cleric:
			return gender === PlayerGender.Female? 'Clerc' :  'Clerc';
		case Class.Wizard:
		default:
			return gender === PlayerGender.Female? 'Magicienne' :  'Magicien';
	}
}

export const getLokalisedSpeciesName = (speciesType: Species, gender: PlayerGender | null = null): string => {
	switch (speciesType) {
		case Species.Human:
			return gender === PlayerGender.Female? 'Humaine' :  'Humain';
		case Species.Elf:
			return gender === PlayerGender.Female? 'Elfe' :  'Elfe';
		case Species.Halfling:
			return gender === PlayerGender.Female? 'Halfeline' :  'Halfelin';
		case Species.Dwarf:
		default:
			return gender === PlayerGender.Female? 'Naine' :  'Nain';
	}
}

export const getLokalisedGenderName= (gender: PlayerGender): string => {
	switch (gender) {
		case PlayerGender.Female:
			return 'Femme';
		case PlayerGender.Male:
			return 'Homme';
		case PlayerGender.NonBinary:
		default:
			return 'Non binaire';
	}
}