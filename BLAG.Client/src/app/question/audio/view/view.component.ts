import { Component, OnInit } from '@angular/core';
import { Audio } from '../audio';

@Component({
  selector: 'app-audio-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class AudioViewComponent implements OnInit {

  constructor() { }

  audio: Audio = {
    id: 1,
    audio: "http://soundboard.panictank.net/wow%20;).mp3",
    points: 1,
    time: 10,
  };

  ngOnInit() {
  }

}
