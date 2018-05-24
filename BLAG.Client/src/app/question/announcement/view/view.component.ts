import { Component, OnInit } from '@angular/core';
import { Announcement } from '../announcement';

@Component({
  selector: 'app-announcement-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class AnnouncementViewComponent implements OnInit {

  constructor() { }

  announcement: Announcement = {
    id: 1,
    title: "Big ass annoucement"
  };

  ngOnInit() {
  }

}
