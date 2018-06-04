import { HubConnection } from '@aspnet/signalr'
import { Observable, of } from 'rxjs';
import { OnInit } from '@angular/core';

export class SignalR implements OnInit {

    public _hubConnection: HubConnection;


    ngOnInit() {
        this._hubConnection = new HubConnection('/gamesession');


        this._hubConnection.start()
            .then(() => {
                console.log('Hub connection started')
            })
            .catch(err => {
                console.log('Error while establishing connection')
            });

        console.log(this._hubConnection);
    }
  
  }