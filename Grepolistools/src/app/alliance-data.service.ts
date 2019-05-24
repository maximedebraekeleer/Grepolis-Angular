import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../environments/environment';
import {map} from 'rxjs/operators';
import {Alliance} from './alliance/alliance.model';

@Injectable({
  providedIn: 'root'
})
export class AllianceDataService
{

  public loadingError$ = new Subject<string>();

  constructor(private http: HttpClient)
  {
  }

  getIdNameMap(server: string, world: number): any
  {
    return this.http.get(`https://grepolistoolsapi20190524025011.azurewebsites.net/api/alliances/namemap/${server}/${world}`).pipe(
      map((list: any): any =>
      {
        return list;
      }));
  }

  getAllianceFromPlayer(id: number, server: string, world: number): Observable<Alliance>
  {
    return this.http.get(`https://grepolistoolsapi20190524025011.azurewebsites.net/api/alliances/player/${id}/${server}/${world}`).pipe(
      map((list: any): Alliance => list)
    );
  }
}
