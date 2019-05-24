import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {Player} from './player.model';
import {PlayerDataService} from '../player-data.service';
import {map} from 'rxjs/operators';
import {AllianceDataService} from '../alliance-data.service';
import {Alliance} from '../alliance/alliance.model';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit
{

  public playerId: number;
  public world: number;
  public server: string;
  private playerData: Observable<Player[]>;
  private playerAlliance: Observable<Alliance>;
  private playerToday: Observable<Player>;
  private playerConquersCount: Observable<number[]>;

  constructor(private aRouter: ActivatedRoute,
              private http: HttpClient,
              private router: Router,
              private _playerDataService: PlayerDataService, private _allianceDataService: AllianceDataService)
  {
  }

  ngOnInit()
  {
    this.aRouter.params.subscribe(params =>
    {
      this.playerId = +params['player'];
      this.world = +params['world'];
      this.server = params['server'];
    });
    this.playerExists();
    this.playerData = this._playerDataService.getSinglePlayerData(this.playerId, this.server, this.world);
    this.playerToday = this.playerData.pipe(map(p => p[0]));
    this.playerConquersCount = this._playerDataService.getConquersFromPlayer(this.playerId, this.server, this.world);
    this.playerAlliance = this._allianceDataService.getAllianceFromPlayer(this.playerId, this.server, this.world);
  }

  playerExists()
  {
    this.http.get(`https://grepolistoolsapi20190524025011.azurewebsites.net/api/Players/checkplayer/${this.playerId}/${this.server}/${this.world}`)
      .toPromise().then((res) =>
    {
      if (!res)
      {
        this.router.navigate(['player/404']);
      }
    });
  }

}
