import { Component, OnInit } from '@angular/core';
import { Text } from './text'
import { APIService } from '../../Services/APIServices'

@Component({
  selector: 'app-text',
  templateUrl: './text.component.html',
  styleUrls: ['./text.component.css']
})
export class TextComponent implements OnInit {

  text: Text =
   {
    id: 1,
    text: "Test Question",
    points: 1,
    time: 10,
  };

  constructor() { }

  //constructor(private apiservice: APIService) { }

  ngOnInit() {
    //this.getTextQuestions
  }

  //getTextQuestions(): void {
  //  this.apiservice.getTextQuestions()
  //  .subscribe(text => this.text = text);
  //}
}
