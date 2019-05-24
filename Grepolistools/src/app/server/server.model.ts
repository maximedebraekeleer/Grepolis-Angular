import {World} from '../world/world.model';
import {FormBuilder, FormGroup} from '@angular/forms';

export class Server
{
  constructor(
    private _name: string,
    private _worlds?: World[]
  )
  {
  }

  public showServer: boolean = true;

  get name(): string
  {
    return this._name;
  }

  get worlds(): World[]
  {
    return this._worlds;
  }

  static fromJSON(json: any): Server
  {
    const s = new Server(json.name, json.worlds);
    return s;
  }
}
