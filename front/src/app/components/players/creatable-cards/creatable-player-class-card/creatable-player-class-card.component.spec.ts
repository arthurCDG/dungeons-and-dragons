import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatablePlayerIconComponent } from './creatable-player-class-card.component';

describe('CreatablePlayerIconComponent', () => {
  let component: CreatablePlayerIconComponent;
  let fixture: ComponentFixture<CreatablePlayerIconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ CreatablePlayerIconComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatablePlayerIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
