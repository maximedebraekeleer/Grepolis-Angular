export class Alliance
{
  constructor(
    private _id: number,
    private _name: string,
    private _points: number,
    private _towns: number,
    private _rank: number,
    private _pointsAttacking: number,
    private _pointsDefending: number,
    private _world: number,
    private _server: string,
    private _date: Date
  )
  {
  }


  get id(): number
  {
    return this._id;
  }

  set id(value: number)
  {
    this._id = value;
  }

  get name(): string
  {
    return this._name;
  }

  set name(value: string)
  {
    this._name = value;
  }

  get points(): number
  {
    return this._points;
  }

  set points(value: number)
  {
    this._points = value;
  }

  get towns(): number
  {
    return this._towns;
  }

  set towns(value: number)
  {
    this._towns = value;
  }

  get rank(): number
  {
    return this._rank;
  }

  set rank(value: number)
  {
    this._rank = value;
  }

  get pointsAttacking(): number
  {
    return this._pointsAttacking;
  }

  set pointsAttacking(value: number)
  {
    this._pointsAttacking = value;
  }

  get pointsDefending(): number
  {
    return this._pointsDefending;
  }

  set pointsDefending(value: number)
  {
    this._pointsDefending = value;
  }

  get world(): number
  {
    return this._world;
  }

  set world(value: number)
  {
    this._world = value;
  }

  get server(): string
  {
    return this._server;
  }

  set server(value: string)
  {
    this._server = value;
  }

  get date(): Date
  {
    return this._date;
  }

  set date(value: Date)
  {
    this._date = value;
  }

  get pointsFighting(): number
  {
    return this._pointsDefending + this._pointsAttacking;
  }

  static fromJSON(json: any): Alliance
  {
    const p = new Alliance(
      json.id, json.name, json.points, json.towns, json.rank, json.pointsAttacking.points, json.pointsDefending.points,
      json.world_Id, json.server_Name, json.date
    );
    return p;
  }
}
