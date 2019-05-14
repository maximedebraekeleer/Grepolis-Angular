import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, Subject} from 'rxjs';
import {World} from './world/world.model';

@Injectable({
  providedIn: 'root'
})
export class WorldDataService {

  public loadingError$ = new Subject<string>();

  constructor(private http:HttpClient) { }

  getWorlds$(server):Observable<World[]>
  {
    return this.http.get("")
  }
}
