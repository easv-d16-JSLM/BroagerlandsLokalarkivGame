import { Component, OnInit } from '@angular/core';
import { Text } from '../text';

@Component({
  selector: 'app-text-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor() { }

  text: Text = {
    id: 1,
    text: "Test Question",
    points: 1,
    time: 10,
  };


  ngOnInit() {
  }

}
