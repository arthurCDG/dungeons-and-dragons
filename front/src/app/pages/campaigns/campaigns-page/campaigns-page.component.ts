import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

import { ICampaign, ICreatableCampaign } from '../../../models';
import { CampaignsService, CreatableCampaignsService } from '../../../services';
import { CampaignCardComponent, CreatableCampaignCardComponent, ImageType, PageBackgroundImageComponent, PageWrapperComponent } from '../../../components';

@Component({
	selector: 'app-campaigns-page',
	standalone: true,
	imports: [
		CommonModule,
		CampaignCardComponent,
		CreatableCampaignCardComponent,
		PageBackgroundImageComponent,
		PageWrapperComponent
	],
	templateUrl: './campaigns-page.component.html',
	providers: [CampaignsService, CreatableCampaignsService]
})
export class CampaignsPageComponent implements OnInit {
	public campaigns$: Observable<ICampaign[]>;
	public creatableCampaigns$: Observable<ICreatableCampaign[]>;

	public backgroundImage: ImageType = 'campaigns-page';

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