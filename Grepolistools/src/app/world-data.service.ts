import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../environments/environment';
import {Subject} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class WorldDataService {

  public loadingError$ = new Subject<string>();

  constructor(private http:HttpClient) { }

  getWorlds$(server):Promise<Object>
  {

    return this.http.get(`${environment.apiUrl}/worlds/${server}`).toPromise();

  }


}
