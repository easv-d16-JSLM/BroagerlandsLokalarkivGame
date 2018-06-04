import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameFlowComponent } from './game-flow.component';

describe('GameFlowComponent', () => {
  let component: GameFlowComponent;
  let fixture: ComponentFixture<GameFlowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameFlowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameFlowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
