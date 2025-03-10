
export interface IStoredItem {
	id: number;
	isEquiped: boolean;
	item: IItem;
	playerId: number;
};

export interface IItem {
	id: string;
	description: string;
	effects: IEffect[];
	explanation: string;
	isUnique: boolean;
	level: number;
	name: string;
	type: ItemType;
};

export interface IEffect {
	amount?: number | undefined;
	effect: EffectType;
	probability: number;
}

export enum EffectType
{
	None = 0,

	// Artifact effects
	IncreaseLifePoints,
	DecreaseLifePoints,
	IncreaseManaPoints,
	DecreaseManaPoints,
	IncreaseShield,
	DecreaseShield,
	IncreaseDamage,
	DecreaseDamage,
	IncreaseStorage,
	DecreaseStorage,
	IncreaseFootSteps,
	DecreaseFootSteps,

	AttackReflectsBackToAttacker,
	AttackReflectsBackToAnotherHero,
	AttackReflectsBackToRandomTarget,

	CanDiscardChestItemToPickAnotherOne,
	PicksTwoOutOfFourChestItems,
	NotAffectedByTrapsWhilePickingChestItems,

	RevealRoomTraps,
	NotAffectedByTraps,
	CanInvokeHeroNearBy,
	CanCastTrapFinderDie,
	DismissAllAttacks,
	IsUndetectableInNextRound,

	// Chest trap effects

	DecreaseAllPlayersLifePoints,
	IncreaseAllMonstersLifePoints,
	DecreaseHeroLifePoints,
	DecreaseRandomMonsterLifePoints,
	DecreaseHeroManaPoints,
	DecreaseHeroNearByLifePoints,
	Lose5LifePointsOrRandomHeroLoses3LifePoints,
	ReviveLastDeadMonster,
	SkipNextTurn,
	AttackRandomHeroNearBy,
	MoveToRandomHero,
	DoesNotAffectLivingCreatures,
	DoesNotAffectUndeads,
	DoesNotAffectHeroes,
	DoesNotAffectMonsters,

	// Potion effects

	DecreaseMonsterLifePoints,
	DecreaseMonsterShieldUntilNextDMTurn,
	DecreaseAllMonstersShieldsUntilNextDMTurn,
	DismissesNextTurnOfMonster,
	DismissesNextTurnOfAllMonsters,
	MoveMonsterToChosenSquare,
	IncreaseAllHeroesFootSteps,
	HeroCanAttackImmediatly,
	HeroCanDismissTrapEffect,
	ReviveHeroWith4LPAnd4MP,
	RequiresHeroToBeNearBy,
	DoubleWeaponStrengthForNextAttack,
	RelaunchAttack,

	// Star die effects 

	IncreaseAllHeroesLifePoints,
	AttackedMonsterPassesHisNextTurn,
	IgnoreMonsterShield,
	NoDamageCaused,
	DoubleHeroAttack,
	DoubleAllHeroesAttacks,
	MoveUndeadToAnySquareInTheRoom,

	// Spell effect

	ReviveAnHeroWith4LifePointsAnd4ManaPoints,
	IncreaseHeroLifePoints,
	MoveMonsterInChosenDirectionByHisNumberOfSteps,
	AllHeroesCanMakeOneStepFreely,
	ProtectsAllHeroesAgainstSpellsAndRangedWeaponsUntilNextDMTurn,

	// Weapon effects
	ProtectsHeroAgainstParalysisWhenUsed,
	IgnoresMonsterShield,
	Costs2ActionPoints,
	IncreasesHeroLifePointsBy1AgainstGnolls,

	// Other
	DiscardAfterUsage
}

export enum ItemType
{
	None = 0,
	Artifact = 1,
	Potion = 2,
	Spell = 3,
	Weapon = 4
}

export interface IArtifact extends IItem {};
export interface IChestTrap extends IItem {};
export interface IPotion extends IItem {};

export interface ISpell extends IItem {
	attributes: ISpellAttributes;
};

export interface ISpellAttributes {
	id: number;
	isMeleeSpellOnly: boolean;
	manaCost: number;
	maximumDamage: number;
	minimumDamage: number;
	spellId: number;
	spellType: SpellType;
}

export enum SpellType {
	Heal,
	Revive,
	Attack,
	Support
};

export interface IWeapon extends IItem {
	superAttack?: IWeaponSuperAttack;
	attributes: IWeaponAttributes;
};

export interface IWeaponSuperAttack {
	effects: IEffect[];
	maximumDamage: number;
	maxSuperAttackCount: number;
	minimumDamage: number;
};

export interface IWeaponAttributes {
	category: WeaponCategory;
	maximumDamage: number;
	minimumDamage: number;
}

export enum WeaponCategory
{
	LightMeleeWeapon,
	MediumMeleeWeapon,
	HeavyMeleeWeapon,
	RangedWeapon,
	Staff
}