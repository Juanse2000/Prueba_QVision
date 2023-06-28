import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeeDetailsComponent } from './see-details.component';

describe('SeeDetailsComponent', () => {
  let component: SeeDetailsComponent;
  let fixture: ComponentFixture<SeeDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeeDetailsComponent]
    });
    fixture = TestBed.createComponent(SeeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
