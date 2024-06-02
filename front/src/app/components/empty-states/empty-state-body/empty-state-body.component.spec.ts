import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmptyStateBodyComponent } from './empty-state-body.component';

describe('EmptyStateBodyComponent', () => {
  let component: EmptyStateBodyComponent;
  let fixture: ComponentFixture<EmptyStateBodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmptyStateBodyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmptyStateBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
