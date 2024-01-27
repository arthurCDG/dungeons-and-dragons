import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaignsService, CreatableCampaignsService } from '../../../services';
import { ICampaign, ICreatableCampaign } from '../../../models';
import { Observable } from 'rxjs';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CampaignCardComponent } from 'src/app/components/campaign-card/campaign-card.component';
import { CreatableCampaignCardComponent } from 'src/app/components/creatable-campaign-card/creatable-campaign-card.component';
import { HeaderComponent } from 'src/app/components/header/header.component';

@Component({
  selector: 'app-campaigns-page',
  standalone: true,
  imports: [CommonModule, CampaignCardComponent, CreatableCampaignCardComponent, HeaderComponent],
  templateUrl: './campaigns-page.component.html',
  styleUrls: ['./campaigns-page.component.css'],
  providers: [CampaignsService, CreatableCampaignsService]
})
export class CampaignsPageComponent implements OnInit {
	public campaigns$: Observable<ICampaign[]>;
	public creatableCampaigns$: Observable<ICreatableCampaign[]>;

	private playerId: number;

	constructor(
		private readonly campaignsService: CampaignsService,
		private readonly creatableCampaignsService: CreatableCampaignsService,
		private readonly activatedRoute: ActivatedRoute
	) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.playerId = Number(params['playerId']));
		this.campaigns$ = this.campaignsService.getAsync(this.playerId);
		this.creatableCampaigns$ = this.creatableCampaignsService.getAsync(this.playerId);
	}
}