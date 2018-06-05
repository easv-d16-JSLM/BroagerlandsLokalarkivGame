import { Component, OnInit } from '@angular/core';
import { Viewquestionnaire } from './viewquestionnaire'
import { APIService } from '../../Services/APIServices'
import { DataSource } from '@angular/cdk/collections';
import { GameFlowComponent } from "../../game-flow/game-flow.component";
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';


@Component({
  selector: 'app-viewquestionnaire',
  templateUrl: './viewquestionnaire.component.html',
  styleUrls: ['./viewquestionnaire.component.css']
})
export class ViewquestionnaireComponent implements OnInit {

  public _hubConnection: HubConnection;

  
  dataSource = new QuestionnaireDataSource(this.apiservice);
  displayedColumns = ['id', 'title', 'actions'];

  constructor(private apiservice: APIService ) { }

  ngOnInit() {

    this._hubConnection = new signalR.HubConnectionBuilder() 
    .configureLogging(signalR.LogLevel.Trace) 
    .withUrl("http://localhost:57851/gamesession") 
    .build(); 

this._hubConnection.start()
  .then(() => {
      console.log('Hub connection started')
  })
  .catch(err => {
      console.log('Error while establishing connection')
  });

console.log(this._hubConnection);
    
// this._hubConnection.on('PlayerCountUpdated', (PlayerCount: number) => {
//   const text = `${nick}: ${receivedMessage}`;
//   this.messages.push(text);
// });

// this._hubConnection.on('CurrentLeaderboard', (leaderboardList: Player) => {
//   const text = `${nick}: ${receivedMessage}`;
//   this.messages.push(text);
// });

// this._hubConnection.on('CurrentQuestion', (currentQuestion: Question, endTime: Date) => {
//   const text = `${nick}: ${receivedMessage}`;
//   this.messages.push(text);
// });

}
  async CreateGameSession(questionnaireId: number){
    console.log("Starting questionnaire " + questionnaireId);
    var session = await this._hubConnection.invoke("CreateGameSession", questionnaireId);
    console.log(session);
  }

  StartGame(currentGameSessionId : number){
    this._hubConnection.invoke("StartGame", currentGameSessionId )

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