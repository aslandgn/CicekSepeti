import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AngManagerBase } from '../AngServiceBase.service';
import { Globals } from 'src/app/helpers/global.helper';
import { IUserService } from '../../abstract/serviceUser/UserService.service';


@Injectable()
export class UserManager extends AngManagerBase<Users> implements IUserService {

  constructor(protected http: HttpClient, globals: Globals) {
    super(globals, "User");
    this._http = http;
  }
  login(model: Users) {
    return this._http.post<Users>(this.url, model);
  }

}
