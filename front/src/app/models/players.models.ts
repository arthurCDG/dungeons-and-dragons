import { IStoredItem } from "./items.models";

export interface ICreatablePlayer {
	firstName: string;
	lastName: string;
	description: string;
	type: PlayerType;
	maxAttributes: IPlayerMaxAttributes;
}

export interface IPlayer {
	id: number;
	userId?: number;
	campaignId: number;
	isDead: boolean;
	squareId?: number;
	profile: IProfile;
	maxAttributes: IPlayerMaxAttributes;
	attributes?: IPlayerAttributes;
	turnOrder?: ITurnOrder;
	storedItems: IStoredItem[];
}

export interface IPlayerAttributes {
	id: number;
	playerId: number;
	lifePoints: number;
	manaPoints: number;
	shield: number;
	footSteps: number;
	attackCount: number;
	healCount: number;
	chestSearchCount: number;
	trapSearchCount: number;
}

export interface IPlayerMaxAttributes {
	id: number;
	playerId: number;
	maxLifePoints: number;
	maxManaPoints: number;
	maxFootSteps: number;
	maxShield: number;
	maxAttackCount: number;
	maxHealCount: number;
	maxChestSearchCount: number;
	maxTrapSearchCount: number;
}

export interface IProfile {
	id: number;
	playerId: number;
	firstName: string;
	lastName: string;
	playerGender: PlayerGender;
	imageUrl: string;
	class?: HeroClass;
	race?: HeroRace;
	monsterType?: MonsterType;
}

export interface ITurnOrder {
	order: number;
	heroId?: number;
	monsterId?: number;
}

export interface IActions {
	remainingFootSteps: number;
    remainingAttacks: number;
    remainingHeals: number;
    remainingChestSearch: number;
    remainingTrapSearch: number;
	heroId?: number;
	monsterId?: number;
}

export interface IAttackPayload {
	meleeAttack?: number;
	rangeAttack?: number;
}

export interface IPlayerCreationPayload {
	playerType: PlayerType;
}

export enum HeroClass {
	Warrior,
    Necromant,
    Healer,
    Fighter,
    Cleric,
    Paladin,
    Rogue,
    Wizard,
    Archer,
    Druid,
    Bard
};

export enum HeroRace {
	Human,
    Elf,
    HalfElf,
    Halfling,
    Dwarf
};

export enum MonsterType {
	BugBear,
    CarrionCrawler,
    Goblin,
    Ghost,
    Gnoll,
    Lich,
    Medusa,
    Ogre,
    Skeleton,
    Troll
}

export enum PlayerGender {
	None,
    Male,
    Female,
    NonBinary
}

export enum PlayerType {
	None,
    Custom,
    Regdar,
    Lidda,
    Jozian,
    Mialye,
    DungeonMaster
}