import { IDieAssociation } from './dice.models';

export interface IStoredItem {
	id: number;
	isEquiped: boolean;
	isDiscarded: boolean;
	heroId: number;
	monsterId: number;
	artefactId: number;
	artefact: IArtefact;
	potionId: number;
	potion: IPotion;
	spellId: number;
	spell: ISpell;
	weaponId: number;
	weapon: IWeapon;
};

export interface IItem {
	id: number;
    campaignId: number;
    name: string;
    cescription: string;
    explanation: string;
    imageUrl: string;
    level: number;
};

export interface IArtefact extends IItem {
	discardAfterUsage: boolean;
	castDieToDiscardAfterUsage: boolean;
	effects: IArtefactEffect[];
};

export interface IArtefactEffect {
	id: number;
	artefactId: number;
	effect: ArtefactEffectType;
};

export interface IChestTrap extends IItem {
	effects: IChestTrapEffect[];
};

export interface IChestTrapEffect {
	id: number;
	chestTrapId: number;
	effect: ChestTrapEffectType;
};

export interface IPotion extends IItem {
	discardAfterUsage: boolean;
	effects: IPotionEffect[];
};

export interface IPotionEffect {
	id: number;
	potionId: number;
	effect: PotionEffectType;
};

export interface ISpell extends IItem {
	manaCost: number;
	type: SpellType;
	isMeleeSpell: boolean;
	isDistantSpell: boolean;
	dice: IDieAssociation[];
	effects: ISpellEffect[];
	starDieEffect?: StarDieEffectType;
};

export interface ISpellEffect {
	id: number;
	spellId: number;
	effect: SpellEffectType;
};

export interface IWeapon extends IItem {
	weaponType: WeaponType;
	dice: IDieAssociation[];
	effects: IWeaponEffect[];
	canRerollOneDie?: boolean;
	superAttack?: IWeaponSuperAttack;
	starDieEffect?: StarDieEffectType;
};

export interface IWeaponEffect {
	id: number;
	weaponId: number;
	effect: WeaponEffectType;
};

export interface IWeaponSuperAttack {
	id: number;
	weaponId: number;
	weaponSuperAttackType: WeaponSuperAttackType;
	dice?: IDieAssociation[];
	losesWeaponAfterSuperAttack?: boolean;
	losesWeaponIfStarDieReturnsStar?: boolean;
};

export enum ArtefactEffectType {
	IncreaseHeroLifePointsBy1,
    IncreaseHeroLifePointsBy2,
    IncreaseHeroLifePointsBy3,
    IncreaseHeroLifePointsBy4,
    IncreaseHeroLifePointsBy5,

    DecreaseHeroLifePointsBy1,
    DecreaseHeroLifePointsBy2,
    DecreaseHeroLifePointsBy3,
    DecreaseHeroLifePointsBy4,
    DecreaseHeroLifePointsBy5,

    IncreaseHeroManaPointsBy1,
    IncreaseHeroManaPointsBy2,
    IncreaseHeroManaPointsBy3,
    IncreaseHeroManaPointsBy4,
    IncreaseHeroManaPointsBy5,

    DecreaseHeroManaPointsBy1,
    DecreaseHeroManaPointsBy2,
    DecreaseHeroManaPointsBy3,
    DecreaseHeroManaPointsBy4,
    DecreaseHeroManaPointsBy5,

    IncreaseHeroShieldBy1,
    IncreaseHeroShieldBy2,
    IncreaseHeroShieldBy3,

    DecreaseHeroShieldBy1,
    DecreaseHeroShieldBy2,
    DecreaseHeroShieldBy3,

    IncreaseHeroStorageBy1,
    IncreaseHeroStorageBy2,
    IncreaseHeroStorageBy3,

    DecreaseHeroStorageBy1,
    DecreaseHeroStorageBy2,
    DecreaseHeroStorageBy3,

    IncreaseHeroFootStepsBy1,
    IncreaseHeroFootStepsBy2,
    IncreaseHeroFootStepsBy3,

    DecreaseHeroFootStepsBy1,
    DecreaseHeroFootStepsBy2,
    DecreaseHeroFootStepsBy3,
    
    AttackReflectsBackToAttacker,
    AttackReflectsBackToAnotherHero,
    AttackReflectsBackToRandomTarget,

    CanDiscardChestItemToPickAnotherOneOneTime,
    CanDiscardChestItemToPickAnotherOneTwoTimes,
    CanDiscardChestItemToPickAnotherOneThreeTimes,
    PicksTwoOutOfFourChestItems,
    NotAffectedByTrapsWhilePickingChestItems,

    RerollDice,
    RevealRoomTraps,
    NotAffectedByTraps,
    CanInvokeHeroNearBy,
    CanCastTrapFinderDie,
    DismissAllAttacks,
    IsUndetectableInNextRound,
};

export enum ChestTrapEffectType {
	DecreaseAllCreaturesLifePointsBy1,
    DecreaseAllCreaturesLifePointsBy2,
    DecreaseAllCreaturesLifePointsBy3,

    IncreaseAllMonstersLifePointsBy1,
    IncreaseAllMonstersLifePointsBy2,
    IncreaseAllMonstersLifePointsBy3,

    DecreaseHeroLifePointsBy1,
    DecreaseHeroLifePointsBy2,
    DecreaseHeroLifePointsBy3,
    DecreaseHeroLifePointsBy4,
    DecreaseHeroLifePointsBy5,

    DecreaseRandomMonsterLifePointsBy1,
    DecreaseRandomMonsterLifePointsBy2,
    DecreaseRandomMonsterLifePointsBy3,

    DecreaseHeroManaPointsBy1,
    DecreaseHeroManaPointsBy2,
    DecreaseHeroManaPointsBy3,
    DecreaseHeroManaPointsBy4,
    DecreaseHeroManaPointsBy5,

    DecreaseHeroNearByLifePointsBy1,
    DecreaseHeroNearByLifePointsBy2,
    DecreaseHeroNearByLifePointsBy3,

    Lose5LifePointsOrRandomHeroLoses3LifePoints,
    ReviveLastDeadMonster,
    SkipNextTurn,
    AttackRandomHeroNearBy,
    MoveToRandomHero,
    DoesNotAffectLivingCreatures,
    DoesNotAffectUndeads,
    DoesNotAffectHeroes,
    DoesNotAffectMonsters
}

export enum PotionEffectType {
	IncreaseHeroLifePointsBy1,
    IncreaseHeroLifePointsBy2,
    IncreaseHeroLifePointsBy3,
    IncreaseHeroLifePointsBy4,
    IncreaseHeroLifePointsBy5,

    IncreaseAllHeroesLifePointsBy1,
    IncreaseAllHeroesLifePointsBy2,
    IncreaseAllHeroesLifePointsBy3,
    IncreaseAllHeroesLifePointsBy4,
    IncreaseAllHeroesLifePointsBy5,

    IncreaseHeroManaPointsBy1,
    IncreaseHeroManaPointsBy2,
    IncreaseHeroManaPointsBy3,
    IncreaseHeroManaPointsBy4,
    IncreaseHeroManaPointsBy5,

    DecreaseMonsterLifePointsBy1,
    DecreaseMonsterLifePointsBy2,
    DecreaseMonsterLifePointsBy3,
    DecreaseMonsterLifePointsBy4,
    DecreaseMonsterLifePointsBy5,

    DecreaseMonsterShieldUntilNextDMTurnBy1,
    DecreaseMonsterShieldUntilNextDMTurnBy2,
    DecreaseMonsterShieldUntilNextDMTurnBy3,

    DecreaseAllMonstersShieldsUntilNextDMTurnBy1,
    DecreaseAllMonstersShieldsUntilNextDMTurnBy2,
    DecreaseAllMonstersShieldsUntilNextDMTurnBy3,

    DismissesNextTurnOfMonster,
    DismissesNextTurnOfAllMonsters,
    MoveMonsterToChosenSquare,

    IncreaseHeroFootStepsBy1,
    IncreaseHeroFootStepsBy2,
    IncreaseHeroFootStepsBy3,
    IncreaseHeroFootStepsBy4,
    IncreaseHeroFootStepsBy5,

    IncreaseAllHeroesFootStepsBy1,
    IncreaseAllHeroesFootStepsBy2,
    IncreaseAllHeroesFootStepsBy3,
    IncreaseAllHeroesFootStepsBy4,
    IncreaseAllHeroesFootStepsBy5,

    HeroCanAttackImmediatly,
    HeroCanDismissTrapEffect,
    
    ReviveHeroWith4LPAnd4MP,

    RequiresHeroToBeNearBy,

    DoubleWeaponStrengthForNextAttack,

    RerollLastCastDie
};

export enum SpellType {
	Heal,
    Revive,
    Attack,
    Support
};

export enum StarDieEffectType {
	IncreaseHeroLifePointsBy1,
    IncreaseHeroLifePointsBy2,
    IncreaseHeroLifePointsBy3,

    IncreaseAllHeroesLifePointsBy1,
    IncreaseAllHeroesLifePointsBy2,
    IncreaseAllHeroesLifePointsBy3,

    DecreaseHeroLifePointsBy1,
    DecreaseHeroLifePointsBy2,
    DecreaseHeroLifePointsBy3,

    IncreaseHeroManaPointsBy1,
    IncreaseHeroManaPointsBy2,
    IncreaseHeroManaPointsBy3,

    DecreaseHeroManaPointsBy1,
    DecreaseHeroManaPointsBy2,
    DecreaseHeroManaPointsBy3,

    AttackedMonsterPassesHisNextTurn,
    IgnoreMonsterShield,
    NoDamageCaused,
    DoubleHeroAttack,
    DoubleAllHeroesAttacks,
    MoveUndeadToAnySquareInTheRoom,
    HeroCanNoLongerRerollDice
};

export enum SpellEffectType {
	ReviveAnHeroWith4LifePointsAnd4ManaPoints,
    IncreaseHeroLifePointsBy1,
    IncreaseHeroLifePointsBy2,
    IncreaseHeroLifePointsBy3,
    IncreaseAllHeroesLifePointsBy1,
    IncreaseAllHeroesLifePointsBy2,
    IncreaseAllHeroesLifePointsBy3,
    MoveMonsterInChosenDirectionByHisNumberOfSteps,
    AllHeroesCanMakeOneStepFreely,
    ProtectsAllHeroesAgainstSpellsAndRangedWeaponsUntilNextDMTurn
};

export enum WeaponEffectType {
	ProtectsHeroAgainstParalysisWhenUsed,
    IgnoresMonsterShield,
    Costs2ActionPoints,
    IncreasesHeroLifePointsBy1AgainstGnolls,
    RerollDiceAndSumUpResults
};

export enum WeaponType {
	LightMeleeWeapon,
    MediumMeleeWeapon,
    HeavyMeleeWeapon,
    RangedWeapon,
    Staff
};

export enum WeaponSuperAttackType {
	CastDice3TimesAndSumUpResult,
    CastDice2TimesAndSumUpResult,
    CastDice
};