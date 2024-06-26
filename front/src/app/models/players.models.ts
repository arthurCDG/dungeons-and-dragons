import { ISquare } from "./campaign.models";
import { IStoredItem } from "./items.models";

export interface ICreatablePlayer {
	associatedSpecies: ICreatableSpecies[];
	class: ICreatableClass;
	description: string;
	lokalisedClassName: string;
	maxAttributes: IPlayerMaxAttributes;
}

export interface ICreatableClass {
	type: Class;
	lokalisedClassName: string;
}

export interface ICreatableSpecies {
	type: Species;
	lokalisedSpeciesName: string;
}

export interface IPlayer {
	id: number;
	userId?: number;
	campaignId: number;
	isAvailable: boolean;
	isDead: boolean;
	squareId?: number;
	square: ISquare;
	profile?: IProfile;
	maxAttributes?: IPlayerMaxAttributes;
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
	name: string;
	gender: PlayerGender;
	imageUrl?: string | null;
	class: Class;
	role: PlayerRole;
	species: Species;
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

/* Payloads */

export interface IAttackPayload {
	attackerId: number;
	receiverId: number;
	type: AttackType
}

export interface IPlayerCreationPayload {
	class: Class;
	gender: PlayerGender;
	name: string;
	species: Species;
}

/* Enums */

export enum Class {
	None = 0,
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
	Bard,
	Soldier,
	Thief,
	PackLeader,
	MonstersKing
};

export enum Species {
	None = 0,
	Human,
	Elf,
	HalfElf,
	Halfling,
	Dwarf,
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
};

export enum PlayerGender {
	None = 0,
	Male,
	Female,
	NonBinary
}

export enum PlayerRole {
	None = 0,
	Hero = 1,
	Monster = 2
}

export enum AttackType {
	None = 0,
	Melee = 1,
	Ranged = 2,
	Spell = 3
}