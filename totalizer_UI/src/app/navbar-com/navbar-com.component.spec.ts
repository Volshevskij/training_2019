import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarComComponent } from './navbar-com.component';

describe('NavbarComComponent', () => {
  let component: NavbarComComponent;
  let fixture: ComponentFixture<NavbarComComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavbarComComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarComComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
