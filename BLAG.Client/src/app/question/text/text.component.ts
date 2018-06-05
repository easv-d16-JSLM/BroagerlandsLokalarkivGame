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
  displayedColumns = ['points', 'time', 'content', 'questiontypes', 'id', 'actions'];

  constructor(private apiservice: APIService) { }

  ngOnInit() {
  }
}



export class TextDataSource extends DataSource<any> {
  constructor(private apiservice: APIService) {
    super();
  }
  connect(): Observable<any> {
    return this.apiservice.getTextQuestions();
  }
  disconnect() {}
}



