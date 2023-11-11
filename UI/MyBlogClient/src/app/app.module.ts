import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpHeaderInterceptorService } from './core/services/app.service';
import { LayoutModule } from './modules/layout/layout.module';
import { MessageService } from 'primeng/api';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { User } from './core/models/user';

export function tokenGetter() {
  var user= JSON.parse(localStorage.getItem("user")!) as User
  return user.token;
}
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    LayoutModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:tokenGetter
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpHeaderInterceptorService,
      multi: true
    },
    MessageService
      
  ],
    
  bootstrap: [AppComponent],
})
export class AppModule { }
