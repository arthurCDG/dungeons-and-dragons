import { IPlayer } from "./players.models";

export interface ICreatableCampaign {
	description: string;
	name: string;
	maxPlayers: number;
	type: CampaignType;
	canBeCreated: boolean;
}

export interface ICampaign {
	id: number;
	name: string;
	description: string;
	type: CampaignType;
	startsAt: Date;
	endsAt?: Date;
	adventures: IAdventure[];
}

export interface ICreatableAdventure {
	name: string;
	description: string;
	type: AdventureType;
	canBeStarted: boolean;
}

export interface IAdventure {
	id: number;
	campaignId: number;
	name: string;
	type: AdventureType;
	status: AdventureStatus;
	squares: ISquare[];
}

export interface ISquare {
	id: number;
	roomId: number;
	imageUrl: string;
	position: IPosition;
	hasTopWall?: boolean;
	hasLeftWall?: boolean;
	hasRightWall?: boolean;
	hasBottomWall?: boolean;
	hasLockedChest?: boolean;
	hasOpenedChest?: boolean;
	hasPillar?: boolean;
	isDisabled?: boolean;
	isDoor?: boolean;
	squareTrap?: ISquareTrap;
	player?: IPlayer
}

export interface IPosition {
	id: number;
	squareId: number;
	x: number;
	y: number;
}

export interface ISquareTrap {
	id: number;
	squareId: number;
	squareTrapType: SquareTrapType;
}

export interface IMovementRequestPayload {
	playerId: number;
	squareId: number;
}

export interface IMovement {
	heroId: number;
	formerSquareId: number;
	newSquareId: number;
}

export enum SquareTrapType {
	Pit,
	ResurrectionOfEvil,
	FireBall,
	PoisonDarts,
	WraparoundRoots,
	CreepingStranglers,
	SpiderWeb,
	CurseOfHeavyBurden,
	CurseOfVulnerability,
	CurseOfTheTreasures,
	SkeletonArrows,
	PivotingSlab,
	GhostlyHands
}

export interface ICampaignPayload {
	dungeonMasterUserId?: number | null;
	playerIds: number[];
	type: CampaignType;
}

export interface IAdventurePayload {
	type: AdventureType;
}

export enum AdventureType {
	None = 0,
	Custom,
	GoblinBandits,
	OnTheTrailOfEvil,
	HauntedVillage,
	KallictakusKey,
	DarknessArmy,
	Pursuit,
	TheTrollsDen,
	TheTempleOfTerror,
	AttackingBorashCastle,
	TheSpiralOfFate,
	TheRiseOfNecratim
}

export enum AdventureStatus {
	None = 0,
	Started = 1,
	Finished = 2
}

export enum CampaignType {
	None = 0,
	HollbrooksLiberation,
	InpursuitOfTheDarkArmy,
	WrathOfTheLich
}