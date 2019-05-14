import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import {ServerDataService} from '../server-data.service';
import {Server} from '../server/server.model';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {

  private _fetchServers$:Observable<Server[]> = this._serverDataService.servers$;
  public currentServer : Observable<Server>;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );


  constructor(private breakpointObserver: BreakpointObserver, public _serverDataService:ServerDataService)
  {
    this.setDefaultServer();
  }

  get servers$(): Observable<Server[]>
  {
    return this._fetchServers$;
  }

  private setDefaultServer() : void
  {
      if(localStorage.getItem("defaultServer"))
      {
        this.currentServer = JSON.parse(localStorage.getItem("defaultServer"));
      }else{
        this.currentServer = this._serverDataService.getServer('nl');
      }
  }



}
