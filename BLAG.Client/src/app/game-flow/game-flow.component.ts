import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';

@Component({
  selector: 'app-game-flow',
  templateUrl: './game-flow.component.html',
  styleUrls: ['./game-flow.component.css']
})
export class GameFlowComponent implements OnInit {
  public _hubConnection: HubConnection;
  public 

  ngOnInit() {
    this._hubConnection = new signalR.HubConnectionBuilder() 
          .configureLogging(signalR.LogLevel.Trace) 
          .withUrl("/gamesession") 
          .build(); 

    this._hubConnection.start()
        .then(() => {
            console.log('Hub connection started')
        })
        .catch(err => {
            console.log('Error while establishing connection')
        });

    console.log(this._hubConnection);
  }

  CreateGameSession(questionnaireId: number){
    this._hubConnection.invoke("CreateGameSession", questionnaireId)
  }

  StartGame(currentGameSessionId : number){
    this._hubConnection.invoke("StartGame", currentGameSessionId )
  }

  RetrieveStatistics(currentGameSessionId : number){
    this._hubConnection.invoke("CurrentLeaderboard", currentGameSessionId)
  }
}
