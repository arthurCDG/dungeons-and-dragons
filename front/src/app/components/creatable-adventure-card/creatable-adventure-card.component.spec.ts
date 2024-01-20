import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatableAdventureCardComponent } from './creatable-adventure-card.component';

describe('CreatableAdventureCardComponent', () => {
  let component: CreatableAdventureCardComponent;
  let fixture: ComponentFixture<CreatableAdventureCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatableAdventureCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatableAdventureCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
