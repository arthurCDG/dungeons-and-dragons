import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ICampaign } from 'src/app/models';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-campaign-card',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './campaign-card.component.html',
  styleUrls: ['./campaign-card.component.css', './../../../styles.css']
})
export class CampaignCardComponent implements OnInit {
	@Input() public campaign: ICampaign;

	constructor() { }

	ngOnInit(): void { }
}
