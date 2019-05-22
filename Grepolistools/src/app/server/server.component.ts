import {Component, Input, OnChanges, OnInit} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit, OnChanges
{

  @Input() private _server: string;

  constructor(private http: HttpClient)
  {
  }

  ngOnInit()
  {
    this.fetchServerStats();
  }

  ngOnChanges()
  {
    this.fetchServerStats();
  }

  private fetchServerStats()
  {
    const serverStats = document.getElementById('serverStatsContent');
    const spinner = document.getElementById('serverStatsContentSpinner');
    serverStats.style.display = 'none';
    spinner.style.display = 'block';
    serverStats.innerHTML = '';
    let countWorlds = document.createElement('span');
    this.http.get(`${environment.apiUrl}/Worlds/count/${this._server}`).toPromise()
      .then((res) =>
      {
        countWorlds.innerText = `Amount of worlds:   ${res}`;
      });
    serverStats.appendChild(countWorlds);
    let countPlayers = document.createElement('span');
    this.http.get(`${environment.apiUrl}/Players/count/${this._server}`).toPromise()
      .then((res) =>
      {
        countPlayers.innerText = `Amount of players:   ${res}`;
      });
    serverStats.appendChild(countPlayers);
    let countAlliances = document.createElement('span');
    this.http.get(`${environment.apiUrl}/Alliances/count/${this._server}`).toPromise()
      .then((res) =>
      {
        countAlliances.innerText = `Amount of Alliances:   ${res}`;
      });
    serverStats.appendChild(countAlliances);
    let countTowns = document.createElement('span');
    this.http.get(`${environment.apiUrl}/Towns/count/${this._server}`).toPromise()
      .then((res) =>
      {
        countTowns.innerText = `Amount of Towns:  ${res}`;
      }).then(() =>
    {
      serverStats.style.display = 'flex';
      spinner.style.display = 'none';
    });
    serverStats.appendChild(countTowns);

  }

}
