import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatablePlayerSpeciesCardComponent } from './creatable-player-species-card.component';

describe('CreatablePlayerSpeciesCardComponent', () => {
  let component: CreatablePlayerSpeciesCardComponent;
  let fixture: ComponentFixture<CreatablePlayerSpeciesCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatablePlayerSpeciesCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreatablePlayerSpeciesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
