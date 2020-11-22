import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAngServiceBase } from '../IAngServiceBase.service';

@Injectable()
export abstract class IUserService extends IAngServiceBase<Users> {

    abstract login(model: Users): Observable<Users | any>
}
