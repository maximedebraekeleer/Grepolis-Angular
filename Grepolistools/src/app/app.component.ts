import {Component} from '@angular/core';
import {Server} from './server/server.model';
import {Observable} from 'rxjs';
import {ServerDataService} from './server-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  private _fetchServers$:Observable<Server[]> = this._serverDataService.servers$;
  public loadingError$ = this._serverDataService.loadingError$;

  constructor(public _serverDataService:ServerDataService)
  {
  }

  get servers$(): Observable<Server[]>
  {
    return this._fetchServers$;
  }


}
