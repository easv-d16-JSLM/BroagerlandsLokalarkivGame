import { Component, OnInit } from '@angular/core';
import { Image } from './image'

@Component({
  selector: 'app-image-view',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})
export class ImageComponent implements OnInit {

  image: Image = {
    id: 1,
    image: "https://upload.wikimedia.org/wikipedia/commons/7/72/16x9_by_Pengo.svg",
    points: 1,
    time: 10,
  };

  constructor() { }

  ngOnInit() {
  }

}
