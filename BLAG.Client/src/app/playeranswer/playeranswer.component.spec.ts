import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayeranswerComponent } from './playeranswer.component';

describe('PlayeranswerComponent', () => {
  let component: PlayeranswerComponent;
  let fixture: ComponentFixture<PlayeranswerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlayeranswerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayeranswerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
