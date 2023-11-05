import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './pages/list/list.component';
import { RouterModule, Routes } from '@angular/router';
import { canActivate } from 'src/app/core/guard/auth-guard';

// const routes: Routes = [
//   { path: "list", component: ListComponent, canActivate: [canActivate] },
// ];

@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    CommonModule,
    // RouterModule.forChild(routes)
  ],
  exports:[
    ListComponent,
  ]
})
export class CategoryModule { }
