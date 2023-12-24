import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaignsService } from '../../../services';
import { ICampaign } from '../../../models';
import { Observable } from 'rxjs';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CampaignCardComponent } from 'src/app/components/campaign-card/campaign-card.component';

@Component({
  selector: 'app-campaigns-page',
  standalone: true,
  imports: [CommonModule, CampaignCardComponent, RouterModule],
  templateUrl: './campaigns-page.component.html',
  styleUrls: ['./campaigns-page.component.css'],
  providers: [CampaignsService]
})
export class CampaignsPageComponent implements OnInit {
	public campaigns$: Observable<ICampaign[]>;

	private playerId: number;

	constructor(
		private readonly campaignsService: CampaignsService,
		private readonly activatedRoute: ActivatedRoute
	) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => this.playerId = Number(params['playerId']));
		this.campaigns$ = this.campaignsService.getAsync(this.playerId);
	}
}