import { Component, OnInit } from '@angular/core';
import { Viewquestionnaire } from './viewquestionnaire'
import { APIService } from '../../Services/APIServices'
import { Observable } from 'rxjs';
import { DataSource } from '@angular/cdk/collections';

@Component({
  selector: 'app-viewquestionnaire',
  templateUrl: './viewquestionnaire.component.html',
  styleUrls: ['./viewquestionnaire.component.css']
})
export class ViewquestionnaireComponent implements OnInit {

  dataSource = new QuestionnaireDataSource(this.apiservice);
  displayedColumns = ['id', 'title', 'questionlist'];

  constructor(private apiservice: APIService) { }

  ngOnInit() {
  }

}

export class QuestionnaireDataSource extends DataSource<any> {
  constructor(private apiservice: APIService) {
    super();
  }
  connect(): Observable<any> {
    return this.apiservice.getQuestionnaires();
  }
  disconnect() {}
}