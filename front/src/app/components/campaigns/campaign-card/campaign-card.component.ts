import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ICampaign } from 'src/app/models';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-campaign-card',
    imports: [CommonModule, RouterModule],
    templateUrl: './campaign-card.component.html',
    styleUrls: ['./campaign-card.component.css', './../../../../styles.css']
})
export class CampaignCardComponent {
	@Input() public campaign: ICampaign;
}
