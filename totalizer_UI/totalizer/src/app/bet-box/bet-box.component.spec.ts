import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BetBoxComponent } from './bet-box.component';

describe('BetBoxComponent', () => {
  let component: BetBoxComponent;
  let fixture: ComponentFixture<BetBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BetBoxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BetBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
