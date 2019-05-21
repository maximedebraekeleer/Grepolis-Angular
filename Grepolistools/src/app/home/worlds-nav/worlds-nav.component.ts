import {Component, Input, OnInit, ViewEncapsulation} from '@angular/core';
import {Observable} from 'rxjs';
import {Server} from '../../server/server.model';
import {FormControl, FormGroup} from '@angular/forms';
import {ServerDataService} from '../../server-data.service';
import {WorldDataService} from '../../world-data.service';
import {map} from 'rxjs/operators';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';

@Component({
  selector: 'app-worlds-nav',
  templateUrl: './worlds-nav.component.html',
  styleUrls: ['./worlds-nav.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class WorldsNavComponent implements OnInit
{

  private _fetchServers$: Observable<Server[]> = this._serverDataService.servers$;
  @Input() private defaultServer: string;
  public navigation: FormGroup;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    public _serverDataService: ServerDataService,
    public _worldDataService: WorldDataService
  )
  {
  }

  ngOnInit(): void
  {
    this.navigation = new FormGroup({
      selectServer: new FormControl(this.defaultServer)
    });
    this.loadWorlds$();
  }


  get servers$(): Observable<Server[]>
  {
    return this._fetchServers$;
  }

  loadWorlds$(): void
  {
    const p = this._worldDataService.getWorlds$(this.navigation.controls['selectServer'].value);
    const selectWorld = document.getElementById('selectWorld');
    p.then((res) =>
    {
      for (var w in res)
      {
        let statusDiv = document.createElement('div');
        let statusDivWrapper = document.createElement('div');
        statusDivWrapper.classList.add('statusDivWrapper');
        statusDivWrapper.appendChild(statusDiv);
        statusDiv.classList.add((res[w].isOpen ? 'worldOpen' : 'worldClosed'));
        let a = document.createElement('a');
        a.appendChild(statusDivWrapper);
        a.href = '#';
        a.classList.add('mat-list-item');
        a.classList.add('selectWorld-item');
        let aDiv = document.createElement('div');
        aDiv.innerHTML = `${res[w].server_Name}${res[w].id} - ${res[w].name}`;
        aDiv.classList.add('mat-list-item-content');
        a.appendChild(aDiv);
        selectWorld.appendChild(a);

      }
    });
  }

}
