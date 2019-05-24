import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {Observable} from 'rxjs';
import {CommonModule} from '@angular/common';
import {Player} from '../player/player.model';
import {PlayerDataService} from '../player-data.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit
{

  private searchParam: string;
  public searchResults: Observable<Player[]>;

  constructor(private aRoute: ActivatedRoute, private _playerDataService: PlayerDataService, private router: Router)
  {

  }

  ngOnInit()
  {
    this.aRoute.params.subscribe(params =>
    {
      this.searchParam = params['searchParam'];
    });
    this.searchResults = this._playerDataService.getPlayerByName(this.searchParam);
  }

  navigateToPlayer(e)
  {
    this.router.navigate([`player/${e.target.id}`]);
  }

}
