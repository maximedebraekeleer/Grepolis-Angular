import {Component, Input, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {Player} from '../player/player.model';
import {PlayerDataService} from '../player-data.service';
import {MaterialModule} from '../material/material.module';

@Component({
  selector: 'app-world',
  templateUrl: './world.component.html',
  styleUrls: ['./world.component.css']
})
export class WorldComponent implements OnInit
{
  get topPlayers(): Observable<Player[]>
  {
    return this._playerDataService.getTopPlayers$(25, this._currentWorld.id, this._currentServer);
  }

  @Input() private _currentWorld: any;
  @Input() private _currentServer: string;
  private _topPlayers: Observable<Player>;

  constructor(private _playerDataService: PlayerDataService)
  {
  }

  ngOnInit()
  {
  }

}
