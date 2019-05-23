import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {Observable} from 'rxjs';
import {Player} from '../player/player.model';
import {PlayerDataService} from '../player-data.service';
import {MatSort, Sort} from '@angular/material';
import {map} from 'rxjs/operators';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-world',
  templateUrl: './world.component.html',
  styleUrls: ['./world.component.css']
})
export class WorldComponent implements OnInit
{

  public world: number;
  public server: string;
  private _topPlayers: Observable<Player[]>;
  public displayedColumns: String[] = ['rank', 'name', 'alliance', 'points', 'attackers', 'defenders', 'fighters', 'towns'];

  @ViewChild(MatSort) sort: MatSort;

  constructor(private _playerDataService: PlayerDataService, private router: Router, private aRouter: ActivatedRoute)
  {

  }

  ngOnInit()
  {
    this.aRouter.params.subscribe(params =>
    {
      this.server = params['server'];
      this.world = params['world'];
    });
    this.loadTopPlayers({active: 'rank', direction: 'asc'});
  }

  sortTable(): void
  {

  }

  loadTopPlayers(sort: Sort)
  {
    this._topPlayers = this._playerDataService.getTopPlayers$(25, this.world, this.server).pipe(
      map((topPlayers: Array<Player>) => topPlayers.sort((d1, d2) => this.sortPlayers(d1, d2, sort)))
    );
  }

  sortPlayers(d1: Player, d2: Player, sort: Sort)
  {
    const one = sort.direction === 'asc' ? 1 : (sort.direction === 'desc' ? -1 : 0);
    if (d1[sort.active] > d2[sort.active])
    {
      return one;
    } else if (d1[sort.active] < d2[sort.active])
    {
      return -one;
    } else
    {
      return 0;
    }
  }

  playerClicked(e)
  {
    this.router.navigate(['player', this.server, this.world, e.target.innerText]);
  }
}
