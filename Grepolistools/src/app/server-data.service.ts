import {Injectable} from '@angular/core';
import {Server} from './server/server.model';
import {HttpClient} from '@angular/common/http';
import {environment} from '../environments/environment';
import {Observable, of, Subject} from 'rxjs';
import {catchError, map} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  export class ServerDataService {

    public loadingError$ = new Subject<string>();

    constructor(private http: HttpClient) { }

    get servers$(): Observable< Server[] >
    {
        return this.http.get(`${environment.apiUrl}/servers`).pipe(
          catchError(error => {this.loadingError$.next(error.statusText); return of (null);}),
            map((list:any):Server[] => list.map(Server.fromJSON))
        );
    }

    getServer(name):Observable<Server>
    {
        return this.http.get(`${environment.apiUrl}/servers/${name}`).pipe(
            map((rec:any):Server => Server.fromJSON(rec))
        );
    }
  }
