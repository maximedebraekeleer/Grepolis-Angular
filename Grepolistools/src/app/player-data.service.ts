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
    return this.http.get(`https://grepolistoolsapi20190524025011.azurewebsites.net/api/players/top/${top}/${server}/${world}`).pipe(
      catchError(error =>
      {
        this.loadingError$.next(error.statusText);
        return of(null);
      }),
      map((list: any): Player[] => list.map(Player.fromJSON))
    );
  }

  getSinglePlayerData(id: number, server: string, world: number)
  {
    return this.http.get(`https://grepolistoolsapi20190524025011.azurewebsites.net/api/players/${id}/${server}/${world}`)
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

  getConquersFromPlayer(id: number, server: string, world: number)
  {
    return this.http.get(`https://grepolistoolsapi20190524025011.azurewebsites.net/api/conquers/player/count/${id}/${server}/${world}`)
      .pipe(map(
        (list: any): number[] => list));
  }
}
