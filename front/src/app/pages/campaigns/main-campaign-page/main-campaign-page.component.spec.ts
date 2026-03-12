import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

import { MainCampaignPageComponent } from './main-campaign-page.component';
import { AdventuresService, CampaignsService, CreatableAdventuresService } from '../../../services';

describe('MainCampaignPageComponent', () => {
  let component: MainCampaignPageComponent;
  let fixture: ComponentFixture<MainCampaignPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ MainCampaignPageComponent ],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            params: of({ campaignId: 1 })
          }
        },
        {
          provide: CampaignsService,
          useValue: {
            getByIdAsync: () => of({
              id: 1,
              name: 'Campaign',
              description: 'Description',
              type: 0,
              startsAt: new Date(),
              adventures: []
            })
          }
        },
        {
          provide: CreatableAdventuresService,
          useValue: {
            getAsync: () => of([])
          }
        },
        {
          provide: AdventuresService,
          useValue: {}
        }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainCampaignPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
