import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { ActivatedRoute } from '@angular/router';
import { ICreatablePlayer, IPlayerCreationPayload } from '../../models';
import { CreatablePlayersService, PlayersService } from '../../services';

@Component({
  selector: 'app-player-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	ReactiveFormsModule,
	MatRadioModule
  ],
  templateUrl: './player-creation-page.component.html',
  styleUrls: ['./player-creation-page.component.css'],
  providers: [
	PlayersService,
	CreatablePlayersService
  ]
})
export class PlayerCreationPageComponent implements OnInit {
	private userId: number;

	public creatablePlayers: ICreatablePlayer[] = [];
	public selectedPlayer: ICreatablePlayer | null = null;

	playerTypeCtrl = this.fb.control(null, Validators.required);
	playerCreationForm = this.fb.group({
		playerType: this.playerTypeCtrl,
	});
	
	constructor(
		private readonly fb: FormBuilder,
		private readonly playersService: PlayersService,
		private readonly creatablePlayersService: CreatablePlayersService,
		private readonly route: ActivatedRoute
	) { }
	
	ngOnInit(): void {
		this.route.params.subscribe(params => this.userId = Number(params['userId']));
		this.creatablePlayersService.getAsync(this.userId).subscribe(creatablePlayers => this.creatablePlayers = creatablePlayers);
	}

	onSubmit(): void {
		const payload: IPlayerCreationPayload = {
			playerType: this.playerTypeCtrl.value!,
		};

		this.playersService.createAsync(this.userId, payload).subscribe(player => console.log('Player created!', player));
	}
}