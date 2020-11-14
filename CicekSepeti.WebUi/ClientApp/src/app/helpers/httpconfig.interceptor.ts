import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { map, catchError } from "rxjs/operators";
import { Router } from "@angular/router";
declare let alertify :any;

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
  constructor(
    private router: Router
  ) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!request.headers.has("Content-Type")) {
      request = request.clone({    
        headers: request.headers.set("Content-Type", "application/json")
      });
    }
    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
        }
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        if (error.status === 400) {
          if(error.error.startsWith('--')){
            alert(error.error.slice(2));
            return throwError(error);
          }
          else{
            alert("error");
          }
        }
        else if (error.status === 401) {
          alert("no authorized");
          return throwError(error);
        }
        else if (error.status === 403) {
          alert("session end");
          setTimeout(function(){
            var cookies = document.cookie.split(";");
            for (var i = 0; i < cookies.length; i++) {
                var cookie = cookies[i];
                var eqPos = cookie.indexOf("=");
                var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
                document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
            }
          }, 3000);
          this.router.navigate(["login"]);
        } 
        else if (error.status === 404) {
          return throwError(error);
        }
        else if (error.status === 405) {
          alert("Bu İşlem İçin Yetkiniz Yoktur!");
        } 
        else {
          alert("Sistemde bir hata oluştu, Lütfen sistem yöneticiniz ile iletişime geçiniz!");
          setTimeout(function(){
          }, 3000);
        }
      })
    );
  }
}
