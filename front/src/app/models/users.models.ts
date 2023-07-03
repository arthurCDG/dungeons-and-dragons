import { IPlayer } from "./players.models";

export interface IUserDto {
	id: number;
    name: string;
    password: string;
    pictureUrl?: string;
    players: IPlayer[];
}

export interface IUserPayload {
	name: string;
	password: string;
	pictureUrl?: string;
}