import { Component, OnInit } from '@angular/core';
import { QuestionTypes } from '../../question/question-types.enum';
import { Question } from '../../question/question';

@Component({
  selector: 'app-questions-view',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})

export class QuestionsComponent implements OnInit {

  constructor() {}

  questionsExamples : Question[] = [
    {Points: 1, Time: 10, Content: "question text here 1", Questiontype: QuestionTypes.Text},
    {Points: 2, Time: 10, Content: "question text here 2", Questiontype: QuestionTypes.Text},
    {Points: 5, Time: 10, Content: "question text here 3", Questiontype: QuestionTypes.Text},
    {Points: 4, Time: 10, Content: "question text here 4", Questiontype: QuestionTypes.Announcement},
    {Points: 3, Time: 10, Content: "question text here 5", Questiontype: QuestionTypes.Announcement},
    {Points: 2, Time: 10, Content: "question text here 6", Questiontype: QuestionTypes.Announcement},
    {Points: 2, Time: 10, Content: "question text here 8", Questiontype: QuestionTypes.Video},
    {Points: 1, Time: 10, Content: "question text here 9", Questiontype: QuestionTypes.Video},
    {Points: 5, Time: 10, Content: "question text here 10", Questiontype: QuestionTypes.Video},
    {Points: 4, Time: 10, Content: "question text here 11", Questiontype: QuestionTypes.Image},
    {Points: 5, Time: 10, Content: "question text here 12", Questiontype: QuestionTypes.Image},
    {Points: 2, Time: 10, Content: "question text here 13", Questiontype: QuestionTypes.Image},
    {Points: 1, Time: 10, Content: "question text here 14", Questiontype: QuestionTypes.Audio},
    {Points: 5, Time: 10, Content: "question text here 15", Questiontype: QuestionTypes.Audio},
    {Points: 4, Time: 10, Content: "question text here 16", Questiontype: QuestionTypes.Audio}
    ];
  

  ngOnInit() {
    console.log(this.questionsExamples);
  }

}
