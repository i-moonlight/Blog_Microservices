import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserLoginDto } from '../../models/userLoginDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  userLoginDto: UserLoginDto = new UserLoginDto()
  constructor(private authService: AuthService) {

  }

  login() {
    this.authService.login(this.userLoginDto).subscribe(rv => {
      if (rv.errors == null) {
        localStorage.setItem("token", rv.data.token)
        localStorage.setItem("username", rv.data.username)
      } else {
        alert(rv.errors)
      }
    }, rv => {
      alert(rv.error.errors[0])
    }
    )
  }

}
