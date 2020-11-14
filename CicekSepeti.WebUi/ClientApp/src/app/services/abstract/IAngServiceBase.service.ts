import { Observable } from 'rxjs';

export abstract class IAngServiceBase<T> {

  abstract getAll(): Observable<T[] | any>

  abstract getById(id: number): Observable<T | any>

  abstract add(model: T): Observable<T | any>

  abstract update(id: number,model: T): Observable<T | any>

  abstract delete(id: number): Observable<any>

}
