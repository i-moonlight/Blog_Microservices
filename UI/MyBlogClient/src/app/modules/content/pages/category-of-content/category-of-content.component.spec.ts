import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOfContentComponent } from './category-of-content.component';

describe('CategoryOfContentComponent', () => {
  let component: CategoryOfContentComponent;
  let fixture: ComponentFixture<CategoryOfContentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoryOfContentComponent]
    });
    fixture = TestBed.createComponent(CategoryOfContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
