import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerCreationPageComponent } from './player-creation-page.component';

describe('PlayerCreationPageComponent', () => {
  let component: PlayerCreationPageComponent;
  let fixture: ComponentFixture<PlayerCreationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ PlayerCreationPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerCreationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
