import { Component, OnInit } from '@angular/core';
import { Questionnaire } from '../../questionnaire/questionnaire/questionnaire';
import { QuestionTypes } from '../../question/question-types.enum';

@Component({
  selector: 'app-questionnaire-view',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.css']
})
export class QuestionnaireComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
