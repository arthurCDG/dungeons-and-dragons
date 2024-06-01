import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageBackgroundImageComponent } from './page-background-image.component';

describe('PageBackgroundImageComponent', () => {
  let component: PageBackgroundImageComponent;
  let fixture: ComponentFixture<PageBackgroundImageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageBackgroundImageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageBackgroundImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
