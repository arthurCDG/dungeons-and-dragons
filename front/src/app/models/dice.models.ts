export interface IDieAssociation {
	id: number;
	dieType: DieType;
	artifactId?: number;
	chestTrapId?: number;
	potionId?: number;
	spellId?: number;
	weaponId?: number;
	weaponSuperAttackId?: number;
}

export enum DieType {
	YellowDie,
    OrangeDie,
    RedDie,
    PurpleDie,
    StarDie,
    TurnUndeadDie,
    RevealTrapsDie,
    DismissTrapsDie
}