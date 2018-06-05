import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { Player } from '../player/player';
import { Question } from '../question/question';
import { ScoreboardComponent } from '../home/scoreboard/scoreboard.component';

@Component({
  selector: 'app-game-flow',
  templateUrl: './game-flow.component.html',
  styleUrls: ['./game-flow.component.css']
})
export class GameFlowComponent implements OnInit {

  public _hubConnection: HubConnection;
  public _playerList: any[];
  public _currentQuestion: Question; 
  public _playerCountUpdate: number;
  
  @ViewChild(ScoreboardComponent)
  private con: ScoreboardComponent;

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
     this._playerCountUpdate = PlayerCount;
    });

    this._hubConnection.on('CurrentLeaderboard', (leaderboardList: any) => {
      this._playerList = leaderboardList;
      this.con.SetPlayerList(this._playerList);
    });

    this._hubConnection.on('CurrentQuestion', (currentQuestion: Question, endTime: any) => {
    this._currentQuestion = currentQuestion;
    });

  }
  
}
