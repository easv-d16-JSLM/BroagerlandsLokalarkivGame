import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { Player } from '../player/player';
import { Question } from '../question/question';

@Component({
  selector: 'app-game-flow',
  templateUrl: './game-flow.component.html',
  styleUrls: ['./game-flow.component.css']
})
export class GameFlowComponent implements OnInit {

  public _hubConnection: HubConnection;


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


    this._hubConnection.on('PlayerCountUpdated', (PlayerCount: number) => {
     
    });

    this._hubConnection.on('CurrentLeaderboard', (leaderboardList: any) => {
 
    });

    this._hubConnection.on('CurrentQuestion', (currentQuestion: Question, endTime: any) => {
    
    });

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
