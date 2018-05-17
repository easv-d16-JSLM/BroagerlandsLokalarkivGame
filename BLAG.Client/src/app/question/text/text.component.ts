import { Component, OnInit } from '@angular/core';
import { Text } from './text'

@Component({
  selector: 'app-text',
  templateUrl: './text.component.html',
  styleUrls: ['./text.component.css']
})
export class TextComponent implements OnInit {

  text: Text = {
    id: 1,
    text: "Test Question",
    points: 1,
    time: 10,
  };

  constructor() { }

  ngOnInit() {
  }

}
