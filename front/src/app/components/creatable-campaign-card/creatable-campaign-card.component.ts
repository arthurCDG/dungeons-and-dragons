import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ICreatableCampaign } from 'src/app/models';

@Component({
  selector: 'app-creatable-campaign-card',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './creatable-campaign-card.component.html',
  styleUrls: ['./creatable-campaign-card.component.css']
})
export class CreatableCampaignCardComponent {
	@Input() public creatableCampaign: ICreatableCampaign;

	constructor(private readonly router: Router, private readonly activatedRoute: ActivatedRoute) { }

	onCreatableCampaignClicked(): void {
		this.router.navigateByUrl('/new', { state: { creatableCampaign: this.creatableCampaign }});
	}
}
