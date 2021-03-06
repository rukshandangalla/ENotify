import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  messages: string[] = [];

  private _hubConnection: HubConnection;

  ngOnInit(): void {
    this._hubConnection = new HubConnection('http://localhost:1639/notify');
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this._hubConnection.on('BroadcastMessage', (type: string, payload: string) => {
      this.messages.push(payload);
    });
  }

  addItByMe(): void {
    this._hubConnection.invoke('FromClient', "Notify", "from the client itself")
    .catch(err => console.error(err));
  }
}
