import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './pages/list/list.component';
import { PrimengModule } from '../primeng/primeng.module';
import { RouterModule, Routes } from '@angular/router';
import { canActivate } from 'src/app/core/guard/auth-guard';
import { DetailComponent } from './pages/detail/detail.component';
import { CategoryOfContentComponent } from './pages/category-of-content/category-of-content.component';

const routes: Routes = [
  { path: "", component: ListComponent, canActivate: [canActivate] },
  { path: "detail/:id", component: DetailComponent, canActivate: [canActivate] },
  { path: "category-of-content/:id", component: CategoryOfContentComponent, canActivate: [canActivate] },
];


@NgModule({
  declarations: [
    ListComponent,
    DetailComponent,
    CategoryOfContentComponent
  ],
  imports: [
    CommonModule,
    PrimengModule,
    RouterModule.forChild(routes)
  ]
})
export class ContentModule { }
