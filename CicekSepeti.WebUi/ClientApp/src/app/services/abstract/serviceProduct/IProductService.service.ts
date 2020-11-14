import { Injectable } from '@angular/core';
import { IAngServiceBase } from '../IAngServiceBase.service';

@Injectable()
export abstract class IProductService extends IAngServiceBase<Products> {

}
