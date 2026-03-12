import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { HeaderComponent } from './components';

@Component({
    selector: 'app-root',
    imports: [HeaderComponent, RouterOutlet],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    standalone: true
})
export class AppComponent {
  title = 'dnd-front';
}
