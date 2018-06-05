import { Component, OnInit, Input } from '@angular/core';
import { APIService } from '../../Services/APIServices'
import { DataSource } from '@angular/cdk/collections';
import { GameFlowComponent } from "../../game-flow/game-flow.component";
import { Observable } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';


@Component({
  selector: 'app-scoreboard-view',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.css']
})
export class ScoreboardComponent implements OnInit {

  @Input("hub") _hubConnection: HubConnection;

  constructor() { }

  ngOnInit() {
console.log(this._hubConnection + "TESSSST");
}



}
