import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from "@angular/material/icon";
import { MatSelectModule } from '@angular/material/select';
import { Observable } from 'rxjs';
import { CreatableCampaignCardComponent } from '../../../components/creatable-campaign-card/creatable-campaign-card.component';
import { ICampaign, ICampaignPayload, ICreatableCampaign, IPlayer, IUserDto } from '../../../models';
import { AvailableDungeonMastersService, AvailablePlayersService, CampaignsService, CreatableCampaignsService } from '../../../services';

@Component({
  selector: 'app-campaign-creation-page',
  standalone: true,
  imports: [
	CommonModule,
	ReactiveFormsModule,
	MatSelectModule,
	MatFormFieldModule,
	MatIconModule
],
  templateUrl: './campaign-creation-page.component.html',
  styleUrls: ['./campaign-creation-page.component.css'],
  providers: [
	CampaignsService,
	AvailableDungeonMastersService,
	AvailablePlayersService
  ]
})
export class CampaignCreationPageComponent implements OnInit {
	@Input() public selectedCampaign: ICreatableCampaign;

	public users$: Observable<IUserDto[]>;
	public players$: Observable<IPlayer[]>;
	public isLoading: boolean = true;
	
	private playerId: number;

	dungeonMasterCtrl = this.fb.control<number | null>(null);
	heroesCtrl = this.fb.record<IPlayer | null>({});
	campaignCreationForm = this.fb.group({
		dungeonMaster: this.dungeonMasterCtrl,
		heroes: this.heroesCtrl
	});

	constructor(
		private readonly fb: FormBuilder,
		private readonly campaignsService: CampaignsService,
		private readonly availableDungeonMastersService: AvailableDungeonMastersService,
		private readonly availablePlayersService: AvailablePlayersService,
		private readonly router: Router,
		private readonly activatedRoute: ActivatedRoute
	) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.playerId = Number(params['playerId']));

		this.users$ = this.availableDungeonMastersService.getAsync();
		this.players$ = this.availablePlayersService.getAsync();

		for (let i = 0; i < this.selectedCampaign.maxPlayers; i++) {
			this.heroesCtrl.addControl(`hero_${i}`, this.fb.control<IPlayer | null>(null))
		}

		this.isLoading = false;
	}

	onSubmit(): void {
		const playerIds: number[] = [this.playerId];
		for (let heroField in this.heroesCtrl.controls) {
			if (this.heroesCtrl.controls[heroField].value) {
				playerIds.push(this.heroesCtrl.controls[heroField].value!.id);
			}
		}

		const payload: ICampaignPayload = {
			type: this.selectedCampaign.type,
			playerIds,
			dungeonMasterUserId: this.dungeonMasterCtrl.value
		};

		this.campaignsService
			.postAsync(payload)
			.subscribe((campaign: ICampaign) => this.router.navigate(['..', campaign.id], { relativeTo: this.activatedRoute }));
	}

	onDeleteClicked(event: Event, index: number): void {
		event.stopPropagation();
		this.heroesCtrl.controls[`hero_${index}`]?.setValue(null);
	}
}
