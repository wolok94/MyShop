import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const url = "https://localhost:63150/api/Customer/login";
    
    if (req.url !== url)
    {
      let token = req.clone({
      setHeaders: {
        Authorization: `bearer ${localStorage.getItem('token')}`
      }
    });
    return next.handle(token);
  }

    return next.handle(req);


  }

}
