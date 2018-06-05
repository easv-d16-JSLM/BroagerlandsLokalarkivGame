import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewquestionnaireComponent } from './viewquestionnaire.component';

describe('ViewquestionnaireComponent', () => {
  let component: ViewquestionnaireComponent;
  let fixture: ComponentFixture<ViewquestionnaireComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewquestionnaireComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewquestionnaireComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
