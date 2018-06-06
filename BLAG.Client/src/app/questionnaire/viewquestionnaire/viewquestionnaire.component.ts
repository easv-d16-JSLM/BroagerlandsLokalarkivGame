import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Viewquestionnaire } from './viewquestionnaire'
import { APIService } from '../../Services/APIServices'
import { DataSource } from '@angular/cdk/collections';
import { GameFlowComponent } from '../../game-flow/game-flow.component';
import { Observable } from 'rxjs';
import { HubConnection } from '@aspnet/signalr';
import { Session } from '../../settings/sessions/sessions';
import { ConnectComponent } from '../../home/connect/connect.component';

@Component({
  selector: 'app-viewquestionnaire',
  templateUrl: './viewquestionnaire.component.html',
  styleUrls: ['./viewquestionnaire.component.css']
})
export class ViewquestionnaireComponent implements OnInit {



  @Input('hub') _hubConnection: HubConnection;

  public _session: Session;

  @ViewChild(ConnectComponent)
  private con: ConnectComponent;


  dataSource = new QuestionnaireDataSource(this.apiservice);
  displayedColumns = ['id', 'title', 'actions'];

  constructor(private apiservice: APIService) { }

  ngOnInit() {

  }

  async CreateGameSession(questionnaireId: number) {
    console.log('Starting questionnaire ' + questionnaireId);
    var _session = await this._hubConnection.invoke('CreateGameSession', questionnaireId);
    console.log(_session);
    this.con.SetSession(_session);
  }

}



export class QuestionnaireDataSource extends DataSource<any> {
  constructor(private apiservice: APIService) {
    super();
  }
  connect(): Observable<any> {
    return this.apiservice.getQuestionnaires();
  }
  disconnect() { }
}

