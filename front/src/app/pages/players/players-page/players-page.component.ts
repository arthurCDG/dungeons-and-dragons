import { CommonModule } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute, RouterModule } from '@angular/router';

import {
	BackArrowComponent,
	LoadingSpinnerComponent,
	PageBackgroundImageComponent,
	PageWrapperComponent,
	PlayerCardComponent,
} from '../../../components';
import { PlayersStore } from '../../../stores';

@Component({
    selector: 'app-players-page',
    imports: [
        CommonModule,
        RouterModule,
        PlayerCardComponent,
        BackArrowComponent,
        PageWrapperComponent,
        PageBackgroundImageComponent,
        LoadingSpinnerComponent
    ],
    templateUrl: './players-page.component.html',
    styleUrls: ['./players-page.component.css'],
    providers: [PlayersStore]
})
export class PlayersPageComponent implements OnInit {
	public readonly playersStore = inject(PlayersStore);
	private readonly route = inject(ActivatedRoute);
	private readonly destroyRef = inject(DestroyRef);

	ngOnInit(): void {
		this.route.params
			.pipe(takeUntilDestroyed(this.destroyRef))
			.subscribe(params => {
				void this.playersStore.load(Number(params['userId']));
			});
	}
}