import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SquareComponent } from '../square/square.component';
import { IRoom } from './../../../app/models/campaign.models';
import { RoomsService } from './../../../app/services';

@Component({
  selector: 'app-room',
  standalone: true,
  imports: [CommonModule, SquareComponent],
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css'],
  providers: [RoomsService]
})
export class RoomComponent implements OnInit {
	@Input() room: IRoom; 

	constructor() { }

	ngOnInit(): void {}
}
