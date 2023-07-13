import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignCreationPageComponent } from './campaign-creation-page.component';

describe('CampaignCreationPageComponent', () => {
  let component: CampaignCreationPageComponent;
  let fixture: ComponentFixture<CampaignCreationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ CampaignCreationPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CampaignCreationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
