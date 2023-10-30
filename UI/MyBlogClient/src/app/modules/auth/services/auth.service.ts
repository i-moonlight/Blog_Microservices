import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpHelperService } from 'src/app/core/services/app.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpHelperService) { }

  login(){
    let userDto:UserLoginDto={username:"hamit",password:"123456"}

   return this.httpClient.post("Auth/Login",userDto)
  }

}

export interface UserLoginDto{
username:string;
password:string;
}