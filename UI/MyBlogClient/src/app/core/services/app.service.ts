import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable, ErrorHandler, inject } from '@angular/core';
import { Observable, from, switchMap } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class HttpHelperService {

  apiUrl: string = "http://localhost:5001/api";

  constructor(private http: HttpClient) {
    
  }
  
  get(endpoint: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/${endpoint}`);
  }

  post(endpoint: string, data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/${endpoint}`, data)
  }

  put(endpoint: string, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${endpoint}`, data);
  }

  delete(endpoint: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${endpoint}`);
  }
}





