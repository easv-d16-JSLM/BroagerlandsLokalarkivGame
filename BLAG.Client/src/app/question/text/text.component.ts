import { Component, OnInit } from '@angular/core';
import { Text } from './text'
import { APIService } from '../../Services/APIServices'
import { Observable } from 'rxjs';
import { DataSource } from '@angular/cdk/collections';

@Component({
  selector: 'app-text',
  templateUrl: './text.component.html',
  styleUrls: ['./text.component.css']
})
export class TextComponent implements OnInit {

  dataSource = new TextDataSource(this.apiservice);
  displayedColumns = ['id', 'text', 'points', 'time'];

  //constructor() { }

  constructor(private apiservice: APIService) { }

  ngOnInit() {
   // this.getTextQuestions
  }

  //getTextQuestions(): void {
  //  this.apiservice.getTextQuestions()
  //  .subscribe(text => this.getTextQuestions = text);
  //}
}

export class TextDataSource extends DataSource<any> {
  constructor(private apiservice: APIService) {
    super();
  }
  connect(): Observable<Text[]> {
    return this.apiservice.getTextQuestions();
  }
  disconnect() {}
}



