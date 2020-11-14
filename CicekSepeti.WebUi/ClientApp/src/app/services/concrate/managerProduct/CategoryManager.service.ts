import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AngManagerBase } from '../AngServiceBase.service';
import { Globals } from 'src/app/helpers/global';
import { ICategoryService } from '../../abstract/serviceProduct/ICategoryService.service';


@Injectable()
export class CategoryManager extends AngManagerBase<Categories> implements ICategoryService {
  
  constructor(protected http: HttpClient, globals: Globals) {
    super(globals, "Category");
    this._http = http;
  }

}
