import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InteractiveElementComponent } from './interactive-element.component';

describe('InteractiveElementComponent', () => {
  let component: InteractiveElementComponent;
  let fixture: ComponentFixture<InteractiveElementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ InteractiveElementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InteractiveElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
