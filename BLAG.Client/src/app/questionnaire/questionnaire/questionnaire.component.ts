import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.css']
})
export class QuestionnaireComponent implements OnInit {

  questionnaire = {
    id: 1,
    type: "text test questionnaire",
    points: 1,
    time: 10,
  };

  constructor() { }

  ngOnInit() {
  }

}
