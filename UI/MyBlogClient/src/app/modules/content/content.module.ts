import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './pages/list/list.component';
import { PrimengModule } from '../primeng/primeng.module';
import { RouterModule, Routes } from '@angular/router';
import { canActivate } from 'src/app/core/guard/auth-guard';

const routes: Routes = [
  { path: "", component: ListComponent, canActivate: [canActivate] },
];


@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    CommonModule,
    PrimengModule,
    RouterModule.forChild(routes)
  ]
})
export class ContentModule { }
