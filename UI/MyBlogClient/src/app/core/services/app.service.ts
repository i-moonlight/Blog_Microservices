import { HttpClient, HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable, ErrorHandler, inject } from '@angular/core';
import { Observable, from, switchMap } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})

export class HttpHelperService {

  apiUrl: string = "http://localhost:5000/services";

  constructor(private http: HttpClient) {

  }

  get(endpoint: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/${endpoint}`);
  }

  post(endpoint: string, data: any,header:HttpHeaders=new HttpHeaders()): Observable<any> {
    return this.http.post(`${this.apiUrl}/${endpoint}`, data)
  }

  put(endpoint: string, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${endpoint}`, data);
  }

  delete(endpoint: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${endpoint}`);
  }
}


@Injectable({
  providedIn: 'root'
})
export class HttpHeaderInterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    var user = JSON.parse(localStorage.getItem("user")!) as User
    if (user == null)
      user = new User();
    req = req.clone({
      setHeaders: { Authorization: `Bearer ${user.token}` }
    });
    return next.handle(req);
  }
}







