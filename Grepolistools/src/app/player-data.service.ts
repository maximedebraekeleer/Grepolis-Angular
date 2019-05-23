import {Injectable} from '@angular/core';
import {Observable, of, Subject} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Player} from './player/player.model';
import {environment} from '../environments/environment';
import {catchError, map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlayerDataService
{

  public loadingError$ = new Subject<string>();

  constructor(private http: HttpClient)
  {
  }

  getTopPlayers$(top: number, world: number, server: string): Observable<Player[]>
  {
    return this.http.get(`${environment.apiUrl}/players/top/${top}/${server}/${world}`).pipe(
      catchError(error =>
      {
        this.loadingError$.next(error.statusText);
        return of(null);
      }),
      map((list: any): Player[] => list.map(Player.fromJSON))
    );
  }

  getSinglePlayerData(name: string, server: string, world: number)
  {
    return this.http.get(`${environment.apiUrl}/players/name/${name}/${server}/${world}`)
      .pipe(
        catchError(error =>
        {
          this.loadingError$.next(error.statusText);
          return of(null);
        }),
        map(
          (list: any): Player[] => list.map(Player.fromJSON))
      );
  }
}
