import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Globals } from 'src/app/helpers/global';
import { IAngServiceBase } from '../Abstract/IAngServiceBase.service';

@Injectable()
export abstract class AngManagerBase<T> extends IAngServiceBase<T> {

  public url: string;
  protected _http: HttpClient;
  constructor(protected globals: Globals, protected serviceUrl: string) {
    super();
    this.url = this.globals.url + this.serviceUrl;
  }

  getAll() {
    return this._http.get<T[]>(this.url);
  }

  getById(id: number) {
    return this._http.get<T>(this.url + '/get/' + id);
  }

  add(model: T) {
    console.log(model);
    return this._http.post<T>(this.url, model);
  }

  update(id: number, model: T) {
    return this._http.put(this.url + "/" + id, model);
  }

  delete(id: number): Observable<any> {
    return this._http.delete(this.url + '/' + id);
  }
}
