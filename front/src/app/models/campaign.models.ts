export interface ICampaign {
	id: number;
	startsAt: Date;
	rooms: IRoom[];
}

export interface IRoom {
	id: number;
	campaignId: number;
	squares: ISquare[];
}

export interface ISquare {
	id: number;
	position: IPosition;
	squareTrap: ISquareTrap;
}

export interface IPosition {
	id: number;
	x: number;
	y: number;
}

export interface ISquareTrap {
	id: number;
	squareTrapType: SquareTrapType;
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