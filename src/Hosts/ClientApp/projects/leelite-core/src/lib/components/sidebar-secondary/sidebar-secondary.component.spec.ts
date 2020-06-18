import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarSecondaryComponent } from './sidebar-secondary.component';

describe('SidebarSecondaryComponent', () => {
  let component: SidebarSecondaryComponent;
  let fixture: ComponentFixture<SidebarSecondaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidebarSecondaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarSecondaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
