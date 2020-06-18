import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeeliteAppComponent } from './leelite-app.component';

describe('LeeliteAppComponent', () => {
  let component: LeeliteAppComponent;
  let fixture: ComponentFixture<LeeliteAppComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeeliteAppComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeeliteAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
