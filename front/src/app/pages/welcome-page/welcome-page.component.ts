import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { UsersService } from '../../services';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-welcome-page',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css'],
  providers: [UsersService]
})
export class WelcomePageComponent { }
