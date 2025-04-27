import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
    selector: 'app-back-arrow',
    imports: [CommonModule, RouterModule],
    templateUrl: './back-arrow.component.html',
    styleUrls: ['./back-arrow.component.css']
})
export class BackArrowComponent {
	@Input() text: string;
	@Input() link: string;
	@Input() fontMode: 'light' | 'dark' = 'light';

	constructor(public readonly activatedRoute: ActivatedRoute) { }
}
