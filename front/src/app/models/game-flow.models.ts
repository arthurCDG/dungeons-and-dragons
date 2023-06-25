import { IPlayer } from "./players.models";

export interface ICurrentPlayerDto {
	adventureId: number;
	player?: IPlayer;
}