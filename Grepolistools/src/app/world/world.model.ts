export class World
{
  constructor(
    private _name: string,
    private _id: number,
    private _server: string,
    private _isOpen: boolean,
    private _isDomination?: boolean
  )
  {}

  get name(): string
  {
    return this._name;
  }

  get id(): number
  {
    return this._id;
  }

  get server(): string
  {
    return this._server;
  }

  get isOpen(): boolean
  {
    return this._isOpen;
  }

  get isDomination(): boolean
  {
    return this._isDomination;
  }

  static fromJSON(json:any):World{
    const w = new World(json.name, json.id, json.server_Name, json.isOpen, json.isDomination);
    return w;
  }
}
