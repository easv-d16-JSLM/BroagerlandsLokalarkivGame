import { Component, OnInit } from '@angular/core';
import { Image } from './image'

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})
export class ImageComponent implements OnInit {

  image: Image = {
    id: 1,
    image: "",
    points: 1,
    time: 10,
  };

  constructor() { }

  ngOnInit() {
  }

}
