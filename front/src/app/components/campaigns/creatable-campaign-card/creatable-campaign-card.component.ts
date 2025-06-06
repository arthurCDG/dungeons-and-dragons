import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ICreatableCampaign } from 'src/app/models';

@Component({
    selector: 'app-creatable-campaign-card',
    imports: [CommonModule, RouterModule],
    templateUrl: './creatable-campaign-card.component.html',
    styleUrls: ['./creatable-campaign-card.component.css']
})
export class CreatableCampaignCardComponent {
	@Input() public creatableCampaign: ICreatableCampaign;

	private playerId: number;
	private userId: number;

	constructor(private readonly router: Router, private readonly activatedRoute: ActivatedRoute) { }

	ngOnInit(): void {
		this.activatedRoute.params.subscribe(params => {
			this.playerId = Number(params['playerId']);
			this.userId = Number(params['userId']);
		});
	}

	onCreatableCampaignClicked(): void {
		this.router.navigate(
			['new'],
			{
				state: { creatableCampaign: this.creatableCampaign },
				relativeTo: this.activatedRoute
			}
		);
	}
}
