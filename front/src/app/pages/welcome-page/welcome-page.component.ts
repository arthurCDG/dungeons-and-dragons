import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { UsersService } from '../../services';

@Component({
  selector: 'app-welcome-page',
  standalone: true,
  imports: [CommonModule, HeaderComponent],
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css'],
  providers: [UsersService]
})
export class WelcomePageComponent { }
