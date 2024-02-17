import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatablePlayerCardComponent } from './creatable-player-card.component';

describe('CreatablePlayerCardComponent', () => {
  let component: CreatablePlayerCardComponent;
  let fixture: ComponentFixture<CreatablePlayerCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ CreatablePlayerCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatablePlayerCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
