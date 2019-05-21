import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit
{

  private _server: string = (localStorage.getItem('defaultServer') ? localStorage.getItem('defaultServer') : 'nl');

  constructor(private http: HttpClient)
  {
  }

  ngOnInit()
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
}
