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

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver, public _serverDataService:ServerDataService) {}

  get servers$(): Observable<Server[]>
  {
    return this._fetchServers$;
  }

}
