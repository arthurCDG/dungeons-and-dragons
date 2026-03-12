import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';

import { AdventurePageComponent } from './adventure-page.component';
import {
  AdventuresService,
  AttacksService,
  ChestItemsService,
  GameFlowService,
  PlayersService,
  SquareMovementService,
  SquaresService
} from '../../services';

describe('AdventurePageComponent', () => {
  let component: AdventurePageComponent;
  let fixture: ComponentFixture<AdventurePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ AdventurePageComponent ],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            params: of({ campaignId: 1, adventureId: 1, userId: 1, playerId: 1 })
          }
        },
        {
          provide: AdventuresService,
          useValue: {
            getByIdAsync: () => of({ id: 1, campaignId: 1, name: 'Adventure', type: 0, startsAt: new Date(), squares: [] })
          }
        },
        {
          provide: PlayersService,
          useValue: {
            getByIdAsync: () => of({
              id: 1,
              campaignId: 1,
              isAvailable: true,
              isDead: false,
              square: { id: 1, roomId: 1, imageUrl: '', position: { id: 1, squareId: 1, x: 0, y: 0 } },
              storedItems: []
            })
          }
        },
        {
          provide: GameFlowService,
          useValue: {
            getCurrentPlayer: () => of({
              adventureId: 1,
              player: {
                id: 1,
                userId: 1,
                campaignId: 1,
                isAvailable: true,
                isDead: false,
                square: { id: 1, roomId: 1, imageUrl: '', position: { id: 1, squareId: 1, x: 0, y: 0 } },
                storedItems: []
              }
            }),
            setNextCurrentPlayer: () => of({ adventureId: 1, player: null })
          }
        },
        {
          provide: SquaresService,
          useValue: {
            getByIdAsync: () => of({ id: 1, roomId: 1, imageUrl: '', position: { id: 1, squareId: 1, x: 0, y: 0 } }),
            getPlayerIfAnyAsync: () => of(null)
          }
        },
        {
          provide: SquareMovementService,
          useValue: {
            MoveToPositionAsync: () => of({ heroId: 1, formerSquareId: 1, newSquareId: 2 })
          }
        },
        {
          provide: AttacksService,
          useValue: {
            attackPlayerAsync: () => of(null)
          }
        },
        {
          provide: ChestItemsService,
          useValue: {
            get: () => of({ item: { id: 1, name: 'Potion' } })
          }
        }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdventurePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
