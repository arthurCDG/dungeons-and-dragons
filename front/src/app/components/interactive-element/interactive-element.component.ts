import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-interactive-element',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './interactive-element.component.html',
  styleUrls: ['./interactive-element.component.css']
})
export class InteractiveElementComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
