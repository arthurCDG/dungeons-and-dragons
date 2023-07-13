import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-campaign-creation-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './campaign-creation-page.component.html',
  styleUrls: ['./campaign-creation-page.component.css']
})
export class CampaignCreationPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
