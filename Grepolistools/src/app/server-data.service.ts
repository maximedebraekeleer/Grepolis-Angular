  import { Injectable } from '@angular/core';
  import {Server} from './server/server.model';
  import {HttpClient} from '@angular/common/http';
  import {environment} from '../environments/environment';
  import {Observable, pipe} from 'rxjs';
  import {catchError, map} from 'rxjs/operators';

  @Injectable({
    providedIn: 'root'
  })
  export class ServerDataService {

    constructor(private http: HttpClient) { }

    get servers$(): Observable< Server[] >
    {
        return this.http.get(`${environment.apiUrl}/servers`).pipe(
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
