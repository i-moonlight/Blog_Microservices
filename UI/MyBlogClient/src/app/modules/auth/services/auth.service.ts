import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpHelperService } from 'src/app/core/services/app.service';
import { UserLoginDto } from '../models/userLoginDto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  identityUrl: string = "http://localhost:5001/api";

  constructor(private http: HttpClient) {

  }

  login(userLoginDto:UserLoginDto):Observable<any> {
    return this.http.post(`${this.identityUrl}/Auth/Login`, userLoginDto)
  }

}
