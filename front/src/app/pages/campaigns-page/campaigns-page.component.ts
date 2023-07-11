import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ICampaign } from '../../models';
import { CampaignsService } from '../../services';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-campaigns-page',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './campaigns-page.component.html',
  styleUrls: ['./campaigns-page.component.css'],
  providers: [CampaignsService]
})
export class CampaignsPageComponent implements OnInit {
	constructor(private readonly campaignsService: CampaignsService, private readonly route: ActivatedRoute) { }

	private playerId: number;
	public campaigns: ICampaign[] = [];

	ngOnInit(): void {
		this.route.params.subscribe(params => this.playerId = Number(params['playerId']));
	
		this.campaignsService.getAsync(this.playerId).subscribe((campaigns: ICampaign[]) => {
			this.campaigns = campaigns;
		});
	}

}
