import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainFormComponentComponent } from './main-form-component.component';

describe('MainFormComponentComponent', () => {
  let component: MainFormComponentComponent;
  let fixture: ComponentFixture<MainFormComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainFormComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainFormComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
