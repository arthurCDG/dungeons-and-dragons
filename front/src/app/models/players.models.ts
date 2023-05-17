import { IStoredItem } from "./items.models";

export interface IPlayer {
	id: number;
	campaignId: number;
	name: string;
	lifePoints: number;
	manaPoints: number;
	shield: number;
	footSteps: number;
	imageUrl: string;
	isDead: boolean;
}

export interface IHero extends IPlayer {
	squareId: number;
	class: HeroClass;
	race: HeroRace;
	storedItems: IStoredItem[];
};

export interface IMonster extends IPlayer {
	squareId: number;
	type: MonsterType;
	storedItems: IStoredItem[];
};

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