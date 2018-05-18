import { Component, OnInit } from '@angular/core';
import { Video } from './video'

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {

  video: Video = {
    id: 1,
    video: "",
    points: 1,
    time: 10,
  };

  constructor() { }

  ngOnInit() {
  }

}
