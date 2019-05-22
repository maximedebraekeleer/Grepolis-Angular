import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnChanges
{

  private _server: string = (localStorage.getItem('defaultServer') ? localStorage.getItem('defaultServer') : 'nl');
  @Input() private _selectedWorld: any;
  public _showServerHome: boolean = true;

  constructor(private http: HttpClient, private router: Router)
  {

  }

  ngOnInit()
  {
  }

  ngOnChanges(changes: SimpleChanges): void
  {

  }

  get server(): string
  {
    return this._server;
  }

  set server(value: string)
  {
    this._server = value;
    localStorage.setItem('defaultServer', value);
  }

  get selectedWorld(): any
  {
    return this._selectedWorld;
  }

  set selectedWorld(value: any)
  {
    this._selectedWorld = value;
  }

  selectedWorldChangedHandler(selectedWorld: any)
  {
    this.selectedWorld = (selectedWorld);
    this._showServerHome = false;
    this.router.navigate(['home']);
  }

  defaultServerChangedHandler(defaultServer: string)
  {
    this._server = defaultServer;
    localStorage.setItem('defaultServer', defaultServer);
    this._showServerHome = true;
  }
}
