import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AngManagerBase } from '../AngServiceBase.service';
import { Globals } from 'src/app/helpers/global';
import { IProductService } from '../../abstract/serviceProduct/IProductService.service';


@Injectable()
export class ProductManager extends AngManagerBase<Products> implements IProductService {
  
  constructor(protected http: HttpClient, globals: Globals) {
    super(globals, "Product");
    this._http = http;
  }

}
