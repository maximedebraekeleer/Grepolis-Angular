import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {Player} from './player.model';
import {PlayerDataService} from '../player-data.service';
import {map} from 'rxjs/operators';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit
{

  public playerName: string;
  public world: number;
  public server: string;
  private playerData: Observable<Player[]>;
  private playerToday: Observable<Player>;

  constructor(private aRouter: ActivatedRoute,
              private http: HttpClient,
              private router: Router,
              private _playerDataService: PlayerDataService)
  {
  }

  ngOnInit()
  {
    this.aRouter.params.subscribe(params =>
    {
      this.playerName = params['name'];
      this.world = +params['world'];
      this.server = params['server'];
    });
    this.playerExists();
    this.playerData = this._playerDataService.getSinglePlayerData(this.playerName, this.server, this.world);
    this.playerToday = this.playerData.pipe(map(p => p[0]));
    this.loadData();
  }

  playerExists()
  {
    this.http.get(`${environment.apiUrl}/Players/checkplayer/${this.playerName}/${this.server}/${this.world}`)
      .toPromise().then((res) =>
    {
      if (!res)
      {
        this.router.navigate(['player/404']);
      }
    });
  }

  loadData()
  {
    const conquerLi = document.getElementById('conquers');
    this.http.get(`${environment.apiUrl}/conquers/player/count/${this.playerName}/${this.server}/${this.world}`)
      .toPromise().then((res) =>
    {
      let span1 = document.createElement('span');
      let span2 = document.createElement('span');
      span1.classList.add('conquered');
      span2.classList.add('losses');
      span1.textContent = `+${res[0]}`;
      span2.textContent = `-${res[1]}`;
      conquerLi.appendChild(span1);
      conquerLi.appendChild(span2);
    });
  }
}
