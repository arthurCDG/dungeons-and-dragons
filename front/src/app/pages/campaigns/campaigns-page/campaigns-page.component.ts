import { CommonModule } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute } from '@angular/router';

import { BackArrowComponent, CampaignCardComponent, CreatableCampaignCardComponent, ImageType, PageBackgroundImageComponent, PageWrapperComponent } from '../../../components';
import { CampaignsStore } from '../../../stores';

@Component({
    selector: 'app-campaigns-page',
    imports: [
        CommonModule,
        CampaignCardComponent,
        CreatableCampaignCardComponent,
        PageBackgroundImageComponent,
        PageWrapperComponent,
        BackArrowComponent
    ],
    templateUrl: './campaigns-page.component.html',
    providers: [CampaignsStore]
})
export class CampaignsPageComponent implements OnInit {
	public readonly campaignsStore = inject(CampaignsStore);

	public backgroundImage: ImageType = 'campaigns-page';

	private readonly activatedRoute = inject(ActivatedRoute);
	private readonly destroyRef = inject(DestroyRef);

	ngOnInit(): void {
		this.activatedRoute.params
			.pipe(takeUntilDestroyed(this.destroyRef))
			.subscribe(params => {
				void this.campaignsStore.load(Number(params['playerId']));
			});
	}
}