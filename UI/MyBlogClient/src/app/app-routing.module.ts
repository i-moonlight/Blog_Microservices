import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLayoutComponent } from './modules/layout/pages/app.layout.component';
import { canActivate } from './core/guard/auth-guard';

const routes: Routes = [
  { path: "auth", loadChildren: () => import("./modules/auth/auth.module").then(x => x.AuthModule) },
  {
    path: "", component: AppLayoutComponent, canActivate: [canActivate], children:
      [
        { path: "contents", loadChildren: () => import("./modules/content/content.module").then(x => x.ContentModule) },
        { path: "categories", loadChildren: () => import("./modules/category/category.module").then(x => x.CategoryModule) }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
