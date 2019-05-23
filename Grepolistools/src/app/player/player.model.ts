export class Player
{
  constructor(private _id: number,
              private _name: string,
              private _alliance: number,
              private _points: number,
              private _rank: number,
              private _towns: number,
              private _world_id: number,
              private _server_Name: string,
              private _date: Date,
              private _pointsAttacking: number,
              private _pointsDefending: number,
              private _pointsFighting: number = _pointsAttacking + _pointsDefending
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

  get rank(): number
  {
    return this._rank;
  }

  set rank(value: number)
  {
    this._rank = value;
  }

  get towns(): number
  {
    return this._towns;
  }

  set towns(value: number)
  {
    this._towns = value;
  }

  get world_id(): number
  {
    return this._world_id;
  }

  set world_id(value: number)
  {
    this._world_id = value;
  }

  get server_Name(): string
  {
    return this._server_Name;
  }

  set server_Name(value: string)
  {
    this._server_Name = value;
  }

  get date(): Date
  {
    return this._date;
  }

  set date(value: Date)
  {
    this._date = value;
  }

  get alliance(): number
  {
    return this._alliance;
  }

  set alliance(value: number)
  {
    this._alliance = value;
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

  get pointsFighting(): number
  {
    return this._pointsFighting;
  }

  set pointsFighting(value: number)
  {
    this._pointsFighting = value;
  }

  static fromJSON(json: any): Player
  {
    const p = new Player(json.id, json.name, json.alliance_Id, json.points, json.rank,
      json.towns, json.world_Id, json.server_Name, json.date, json.pointsAttacking.points, json.pointsDefending.points);
    return p;
  }
}
