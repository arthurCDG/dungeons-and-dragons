import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignsPageComponent } from './main-campaign-page.component';

describe('CampaignsPageComponent', () => {
  let component: CampaignsPageComponent;
  let fixture: ComponentFixture<CampaignsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CampaignsPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CampaignsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
