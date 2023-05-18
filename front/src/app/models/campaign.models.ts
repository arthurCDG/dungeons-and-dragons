import { IHero, IMonster } from "./players.models";

export interface ICampaign {
	id: number;
	startsAt: Date;
	endsAt?: Date;
	adventure: Adventure;
	squares: ISquare[];
}

// export interface IRoom {
// 	id: number;
// 	campaignId: number;
// 	squares: ISquare[];
// 	isStartRoom?: boolean;
// }

export interface ISquare {
	id: number;
	roomId: number;
	imageUrl: string;
	position: IPosition;
	hasTopWall: boolean;
	hasLeftWall: boolean;
	hasRightWall: boolean;
	hasBottomWall: boolean;
	isDisabled: boolean;
	isDoor: boolean;
	squareTrap: ISquareTrap;
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
	heroId: number;
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
	adventure : Adventure;
}

export enum Adventure {
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