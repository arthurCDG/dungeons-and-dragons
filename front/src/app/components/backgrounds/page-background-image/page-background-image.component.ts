import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-page-background-image',
  standalone: true,
  templateUrl: './page-background-image.component.html',
  styleUrl: './page-background-image.component.css'
})
export class PageBackgroundImageComponent {
	@Input() image: string;
}

export type ImageType =
	'hollbrook-background-campaign-image'|
	'signup-login-page' |
	'players-creation-page' |
	'campaigns-page' |
	'hollbrook-background-campaign-image' |
	'inpursuit-of-the-dark-army-campaign-image' |
	'wrath-of-the-lich-campaign-image';