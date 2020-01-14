import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LectionsComponent } from './lections.component';

describe('LectionsComponent', () => {
  let component: LectionsComponent;
  let fixture: ComponentFixture<LectionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LectionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
