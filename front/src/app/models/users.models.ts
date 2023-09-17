import { IPlayer } from "./players.models";

export interface IUserDto {
	id: number;
    name: string;
    password: string;
    pictureUrl?: string;
    players: IPlayer[];
	token: string;
}

export interface IUserPayload {
	userName: string;
	password: string;
	pictureUrl?: string;
}

export interface ILoginPayload {
	userName: string;
	password: string;
}