import { CommonModule } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute } from '@angular/router';

import {
	ActionBarComponent,
	AdventureLogComponent,
	ImageType,
	LoadingSpinnerComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	SquareComponent
} from '../../components';
import { AdventureStore } from '../../stores';

@Component({
    selector: 'app-adventure-page',
    imports: [
        ActionBarComponent,
		AdventureLogComponent,
        CommonModule,
        LoadingSpinnerComponent,
        PageWrapperComponent,
		PageBackgroundImageComponent,
        SquareComponent,
    ],
    templateUrl: './adventure-page.component.html',
    styleUrls: ['./adventure-page.component.css'],
    providers: [AdventureStore]
})
export class AdventurePageComponent implements OnInit {
	public readonly adventureStore = inject(AdventureStore);
	private readonly activatedRoute = inject(ActivatedRoute);
	private readonly destroyRef = inject(DestroyRef);

	ngOnInit(): void {
		this.activatedRoute.params
			.pipe(takeUntilDestroyed(this.destroyRef))
			.subscribe(params => {
				void this.adventureStore.load({
					campaignId: Number(params['campaignId']),
					adventureId: Number(params['adventureId']),
					userId: Number(params['userId']),
					playerId: Number(params['playerId'])
				});
			});
	}
}
