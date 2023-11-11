import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserLoginDto } from '../../models/userLoginDto';
import { Router } from '@angular/router';
import { User } from 'src/app/core/models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  userLoginDto: UserLoginDto = new UserLoginDto()
  constructor(private authService: AuthService,private router:Router) {

  }

  login() {
    this.authService.login(this.userLoginDto).subscribe(rv => {
      if (rv.errors == null) {
        localStorage.setItem("user", JSON.stringify(rv.data))       
        this.router.navigateByUrl("/")
      } else {
        alert(rv.errors)
      }
    }, rv => {
      alert(rv.error.errors[0])
    }
    )
  }

}
