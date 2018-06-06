import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { Player } from '../player/player';
import { Question } from '../question/question';
import { ScoreboardComponent } from '../home/scoreboard/scoreboard.component';
import { GamescreenComponent } from '../settings/gamescreen/gamescreen.component';
import { RouterModule, Routes, Route, ActivatedRoute } from '@angular/router';
import { Session } from '../settings/sessions/sessions';
import { ConnectComponent } from '../home/connect/connect.component';

@Component({
  selector: 'app-game-flow',
  templateUrl: './game-flow.component.html',
  styleUrls: ['./game-flow.component.css']
})
export class GameFlowComponent implements OnInit {

  constructor(private route: ActivatedRoute) {

  }

  public _session: Session;
  public _hubConnection: HubConnection;

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');

    this._hubConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Trace)
      .withUrl('http://localhost:57851/gamesession')
      .build();

    this._hubConnection.start()
      .then(async () => {
        console.log('Starting questionnaire ' + id);
        this._session = await this._hubConnection.invoke('CreateGameSession', id);
        console.log(this._session);
      })
      .catch(err => {
        console.log('Error while establishing connection');
      });

    console.log(this._hubConnection);


    // this._hubConnection.on('PlayerCountUpdated', (PlayerCount: number) => {
    //  this._playerCountUpdate = PlayerCount;
    // });

    // this._hubConnection.on('CurrentLeaderboard', (leaderboardList: any) => {
    //   this._playerList = leaderboardList;
    //   console.log(this.con);
    //   this.con.SetPlayerList(this._playerList);
    // });

    // this._hubConnection.on('CurrentQuestion', (currentQuestion: Question, endTime: any) => {
    //   this._currentQuestion = currentQuestion;
    //   console.log(this.gs);
    //   this.gs.SetCurrentQuestions(this._currentQuestion, this._endTime);

    // });




  }

  // start function calls signalr startgame
}
