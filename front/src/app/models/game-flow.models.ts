import { IHero, IMonster } from "./players.models";

export interface ICurrentPlayerDto {
	campaignId: number;
	heroId?: number;
	hero?: IHero;
	monsterId?: number;
	monster?: IMonster;
}