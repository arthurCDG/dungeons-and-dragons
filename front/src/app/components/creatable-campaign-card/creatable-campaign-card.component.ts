import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICreatableCampaign } from 'src/app/models';

@Component({
  selector: 'app-creatable-campaign-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './creatable-campaign-card.component.html',
  styleUrls: ['./creatable-campaign-card.component.css']
})
export class CreatableCampaignCardComponent {
	@Input() public creatableCampaign: ICreatableCampaign;
	@Input() public isSelected: boolean;
	@Output() selectedCampaign = new EventEmitter<ICreatableCampaign>();
}
