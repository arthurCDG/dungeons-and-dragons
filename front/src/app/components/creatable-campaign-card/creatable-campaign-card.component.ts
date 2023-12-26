import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ICreatableCampaign } from 'src/app/models';

@Component({
  selector: 'app-creatable-campaign-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './creatable-campaign-card.component.html',
  styleUrls: ['./creatable-campaign-card.component.css']
})
export class CreatableCampaignCardComponent {
	@Input() public campaign: ICreatableCampaign;
}
