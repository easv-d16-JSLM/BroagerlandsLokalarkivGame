import { Component, OnInit } from '@angular/core';
import { Image } from '../image';

@Component({
  selector: 'app-image-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ImageViewComponent implements OnInit {

  constructor() { }

  image: Image = {
    id: 1,
    image: "https://upload.wikimedia.org/wikipedia/commons/7/72/16x9_by_Pengo.svg",
    points: 1,
    time: 10,
  };
  
  ngOnInit() {
  }

}
