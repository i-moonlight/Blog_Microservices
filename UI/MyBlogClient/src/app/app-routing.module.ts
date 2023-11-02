import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:"auth",loadChildren:()=>import("./modules/auth/auth.module").then(x=>x.AuthModule)},
  
  // {path:"category",loadChildren:()=>import("./modules/category/category.module").then(x=>x.CategoryModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
