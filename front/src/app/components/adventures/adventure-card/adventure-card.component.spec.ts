import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdventureCardComponent } from './adventure-card.component';

describe('AdventureCardComponent', () => {
  let component: AdventureCardComponent;
  let fixture: ComponentFixture<AdventureCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ AdventureCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdventureCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
