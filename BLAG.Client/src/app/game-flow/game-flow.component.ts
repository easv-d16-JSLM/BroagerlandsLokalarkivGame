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

  _session: Session;
  _hubConnection: HubConnection;
  joinCode: String = 'Please wait...';
  playerCount: String = 'Not connected';
  questionText: String;
  leaderboard: String;

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');

    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:57851/gamesession')
      .build();

    this._hubConnection.on('PlayerCountUpdated', (PlayerCount: number) => {
      this.playerCount = PlayerCount.toString();
    });

    this._hubConnection.on('CurrentLeaderboard', (leaderboardList: Player[]) => {
      console.log(leaderboardList);
      this.leaderboard = '';
      leaderboardList.forEach(p => {
        this.leaderboard += p.Score + ' ' + p.Name;
      });
    });

    this._hubConnection.on('CurrentQuestion', (currentQuestion: Question, endTime: any) => {
      console.log(currentQuestion);
      this.questionText = currentQuestion.content;
    });


    this._hubConnection.start()
      .then(async () => {
        this._session = await this._hubConnection.invoke('CreateGameSession', id);
        this.joinCode = this._session.joinCode;
        this.playerCount = '0';
        console.log(this._session);
      });

  }

  async StartGame() {
    await this._hubConnection.invoke('StartGame', this._session.id);
  }
}
