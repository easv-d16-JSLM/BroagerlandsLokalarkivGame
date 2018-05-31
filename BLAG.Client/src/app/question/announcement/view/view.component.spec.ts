import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnnouncementViewComponent } from './view.component';

describe('ViewComponent', () => {
  let component: AnnouncementViewComponent;
  let fixture: ComponentFixture<AnnouncementViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnnouncementViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnnouncementViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
