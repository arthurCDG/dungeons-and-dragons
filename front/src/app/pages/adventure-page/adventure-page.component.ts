import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ActionBarComponent } from 'src/app/components/action-bar/action-bar.component';

@Component({
  selector: 'app-adventure-page',
  standalone: true,
  imports: [CommonModule, RouterModule, ActionBarComponent],
  templateUrl: './adventure-page.component.html',
  styleUrls: ['./adventure-page.component.css'],
})
export class AdventurePageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
