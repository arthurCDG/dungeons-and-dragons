import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatableCampaignCardComponent } from './creatable-campaign-card.component';

describe('CreatableCampaignCardComponent', () => {
  let component: CreatableCampaignCardComponent;
  let fixture: ComponentFixture<CreatableCampaignCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ CreatableCampaignCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatableCampaignCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
