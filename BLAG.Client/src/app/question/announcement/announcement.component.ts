import { Component, OnInit } from '@angular/core';
import { Announcement } from './announcement';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.css']
})
export class AnnouncementComponent implements OnInit {

  announcement: Announcement = {
    id: 1,
    title: "Big ass annoucement"
  };

  constructor() { }

  ngOnInit() {
  }

}
