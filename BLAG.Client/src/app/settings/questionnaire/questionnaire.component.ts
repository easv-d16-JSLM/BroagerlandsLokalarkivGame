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

  questionnaireExamples : Questionnaire[] = [
    {id: 1, title: "This is an example", question: [{Points: 1, Time: 10, Content: "question text here 1", Questiontype: QuestionTypes.Text},
    {Points: 2, Time: 10, Content: "question text here 2", Questiontype: QuestionTypes.Text},
    {Points: 5, Time: 10, Content: "question text here 3", Questiontype: QuestionTypes.Text},
  ]}
];

  ngOnInit() {
  }

}
