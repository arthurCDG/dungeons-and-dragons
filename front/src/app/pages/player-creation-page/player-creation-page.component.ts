import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { ActivatedRoute, Router } from '@angular/router';
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
	public selectedPlayer?: ICreatablePlayer;
	public isLoading: boolean = true;

	playerTypeCtrl = this.fb.control(null);
	playerCreationForm = this.fb.group({
		playerType: this.playerTypeCtrl,
	});
	
	constructor(
		private readonly fb: FormBuilder,
		private readonly playersService: PlayersService,
		private readonly creatablePlayersService: CreatablePlayersService,
		private readonly router: Router,
		private readonly route: ActivatedRoute
	) { }
	
	ngOnInit(): void {
		this.route.params.subscribe(params => this.userId = Number(params['userId']));

		this.creatablePlayersService.getAsync(this.userId).subscribe(creatablePlayers => {
			this.creatablePlayers = creatablePlayers;
			this.isLoading = false;
		});

		this.playerTypeCtrl.valueChanges.subscribe(playerType => {
			this.selectedPlayer = this.creatablePlayers.find(creatablePlayer => creatablePlayer.type === playerType)
		});
	}

	onSubmit(): void {
		const payload: IPlayerCreationPayload = {
			playerType: this.playerTypeCtrl.value!,
		};

		this.playersService.createAsync(this.userId, payload).subscribe(player => {
			console.log('Player created!', player);
			this.router.navigate(['../'], { relativeTo: this.route });
		});
	}
}