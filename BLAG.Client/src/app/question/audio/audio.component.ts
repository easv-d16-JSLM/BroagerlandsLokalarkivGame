import { Component, OnInit } from '@angular/core';
import { Audio } from './audio'

@Component({
  selector: 'app-audio',
  templateUrl: './audio.component.html',
  styleUrls: ['./audio.component.css']
})
export class AudioComponent implements OnInit {

  audio: Audio = {
    id: 1,
    audio: "",
    points: 1,
    time: 10,
  };

  constructor() { }

  ngOnInit() {
  }

}
