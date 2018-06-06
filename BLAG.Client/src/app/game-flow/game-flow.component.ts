import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { Player } from '../player/player';
import { Question } from '../question/question';
import { ScoreboardComponent } from '../home/scoreboard/scoreboard.component';
import { GamescreenComponent } from '../settings/gamescreen/gamescreen.component';
import { RouterModule, Routes, Route, ActivatedRoute } from '@angular/router';
import { Sessions } from '../settings/sessions/sessions';
import { ConnectComponent } from '../home/connect/connect.component';

@Component({
  selector: 'app-game-flow',
  templateUrl: './game-flow.component.html',
  styleUrls: ['./game-flow.component.css']
})
export class GameFlowComponent implements OnInit {

  constructor(private route: ActivatedRoute) {

  }

  public _session: Sessions;
  public _hubConnection: HubConnection;
  public _playerList: any[];
  public _currentQuestion: Question;
  public _playerCountUpdate: number;
  public _endTime: any;

  // @ViewChild(ConnectComponent)
  // private conn: ConnectComponent;

  // @ViewChild(ScoreboardComponent)
  // private con: ScoreboardComponent;

  // @ViewChild(GamescreenComponent)
  // private gs: GamescreenComponent;

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');

    this._hubConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Trace)
      .withUrl("http://localhost:57851/gamesession")
      .build();

    this._hubConnection.start()
      .then(async () => {
        await this.CreateGameSession(id)
      })
      .catch(err => {
        console.log('Error while establishing connection')
      });

    console.log(this._hubConnection);


    this._hubConnection.on('PlayerCountUpdated', (PlayerCount: number) => {
      this._playerCountUpdate = PlayerCount;
    });

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

    this.SetSession;



  }

  public SetSession(session: Sessions) {
    console.log(session);

    this._session = session;
  }

  async CreateGameSession(questionnaireId: number) {
    console.log("Starting questionnaire " + questionnaireId);
    var _session = await this._hubConnection.invoke("CreateGameSession", questionnaireId);
    console.log(_session);

    //show joincode

  }
  //start function calls signalr startgame
}
