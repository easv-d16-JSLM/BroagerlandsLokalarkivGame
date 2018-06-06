import { Component, OnInit, Input } from '@angular/core';
import { Question } from '../../question/question';

@Component({
  selector: 'app-gamescreen',
  templateUrl: './gamescreen.component.html',
  styleUrls: ['./gamescreen.component.css']
})
export class GamescreenComponent implements OnInit {

  @Input("currentquestion") public _currentQuestion: Question;
  @Input("endtime") public _endTime: any;
  

  constructor() { }

  ngOnInit() {
  }


  public SetCurrentQuestions(currentQuestion:Question , endtime: any){
    this._endTime=endtime;
    this._currentQuestion=currentQuestion;
  }


}
