import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    localStorage.setItem("token", "123456token");

    const token = localStorage.getItem("token");

    console.log('INTERCEPTOR');
      let newHeaders = req.headers;
      newHeaders = newHeaders.append('authtoken', token);

      // Finally we have to clone our request with our new headers
      // This is required because HttpRequests are immutable
      const authReq = req.clone({headers: newHeaders});
      // Then we return an Observable that will run the request
      // or pass it to the next interceptor if any
      return next.handle(authReq);
  }
}
