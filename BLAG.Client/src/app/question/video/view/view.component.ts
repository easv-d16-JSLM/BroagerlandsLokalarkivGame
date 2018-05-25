import { Component, OnInit } from '@angular/core';
import { Video } from '../video';

@Component({
  selector: 'app-video-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class VideoViewComponent implements OnInit {

  constructor() { }

  video: Video = {
    id: 1,
    video: "http://techslides.com/demos/sample-videos/small.webm",
    points: 1,
    time: 10,
  };

  ngOnInit() {
  }

}
