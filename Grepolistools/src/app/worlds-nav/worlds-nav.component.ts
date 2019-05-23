import {Component, Input, OnInit, ViewEncapsulation} from '@angular/core';
import {Observable} from 'rxjs';
import {Server} from '../server/server.model';
import {FormControl, FormGroup} from '@angular/forms';
import {ServerDataService} from '../server-data.service';
import {WorldDataService} from '../world-data.service';
import {map} from 'rxjs/operators';
import {BreakpointObserver, Breakpoints} from '@angular/cdk/layout';
import {Router} from '@angular/router';

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
  @Input() public selectedWorld: any;

  public navigation: FormGroup;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    public _serverDataService: ServerDataService,
    public _worldDataService: WorldDataService,
    private router: Router
  )
  {
    this.router.routeReuseStrategy.shouldReuseRoute = () =>
    {
      return false;
    };
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
    const p = this._worldDataService.getWorlds$(this.defaultServer);
    const selectWorld = document.getElementById('selectWorld');
    selectWorld.innerHTML = '';
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
        a.classList.add('mat-list-item');
        a.classList.add('selectWorld-item');
        a.onclick = (e) =>
        {
          this.worldClicked(e.target);
        };
        let aDiv = document.createElement('div');
        aDiv.innerHTML = `${res[w].server_Name}${res[w].id} - ${res[w].name}`;
        aDiv.classList.add('mat-list-item-content');
        aDiv.id = `${res[w].server_Name}_${res[w].id}`;
        a.appendChild(aDiv);
        selectWorld.appendChild(a);

      }
    });
  }

  worldClicked(target: EventTarget)
  {
    // @ts-ignore
    let data = target.id.split('_');
    this.router.navigate(['world', this.defaultServer, data[1]]);
  }

  changeServer(e: string): void
  {
    this.router.navigate(['server', e]);
  }

}
