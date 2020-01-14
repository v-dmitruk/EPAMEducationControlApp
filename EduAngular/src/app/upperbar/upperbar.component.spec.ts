import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpperbarComponent } from './upperbar.component';

describe('UpperbarComponent', () => {
  let component: UpperbarComponent;
  let fixture: ComponentFixture<UpperbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpperbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpperbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
