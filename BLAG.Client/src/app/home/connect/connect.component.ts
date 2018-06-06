import { Component, OnInit, Input } from '@angular/core';
import { APIService } from '../../Services/APIServices'
import { DataSource } from '@angular/cdk/collections';
import { GameFlowComponent } from "../../game-flow/game-flow.component";
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { ViewquestionnaireComponent } from "../../../app/questionnaire/viewquestionnaire/viewquestionnaire.component";
import { Session } from '../../settings/sessions/sessions';

@Component({
  selector: 'app-connect-view',
  templateUrl: './connect.component.html',
  styleUrls: ['./connect.component.css']
})
export class ConnectComponent implements OnInit {

  @Input("hub") _hubConnection: HubConnection;

  @Input("session") _session: Session;



  constructor() { }


  ngOnInit() {
  }

  public SetSession(session: Session) {
    console.log(session);

    this._session = session;
  }

  StartGame() {
    console.log(this._hubConnection + "Middagspause")
    this._hubConnection.invoke("StartGame", this._session.id)
  }
}
