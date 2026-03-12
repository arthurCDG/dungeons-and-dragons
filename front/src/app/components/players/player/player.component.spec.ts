import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerComponent } from './player.component';

describe('PlayerComponent', () => {
  let component: PlayerComponent;
  let fixture: ComponentFixture<PlayerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ PlayerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerComponent);
    component = fixture.componentInstance;
    component.player = {
      id: 1,
      campaignId: 1,
      isAvailable: true,
      isDead: false,
      square: {
        id: 1,
        roomId: 1,
        imageUrl: '',
        position: { id: 1, squareId: 1, x: 0, y: 0 }
      },
      storedItems: []
    };
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
