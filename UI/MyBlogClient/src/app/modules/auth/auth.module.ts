import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { PrimengModule } from '../primeng/primeng.module';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: "login", component: LoginComponent },
];

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    PrimengModule,
    FormsModule,
    RouterModule.forChild(routes)
  ]
})
export class AuthModule { }
