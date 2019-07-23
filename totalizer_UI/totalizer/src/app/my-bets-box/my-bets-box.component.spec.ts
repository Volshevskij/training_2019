import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBetsBoxComponent } from './my-bets-box.component';

describe('MyBetsBoxComponent', () => {
  let component: MyBetsBoxComponent;
  let fixture: ComponentFixture<MyBetsBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyBetsBoxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyBetsBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
