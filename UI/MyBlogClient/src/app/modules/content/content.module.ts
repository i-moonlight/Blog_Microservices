import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './pages/list/list.component';
import { PrimengModule } from '../primeng/primeng.module';
import { RouterModule, Routes } from '@angular/router';
import { canActivate } from 'src/app/core/guard/auth-guard';
import { DetailComponent } from './pages/detail/detail.component';
import { CategoryOfContentComponent } from './pages/category-of-content/category-of-content.component';
import { NewComponent } from './pages/new/new.component';
import { EditComponent } from './pages/edit/edit.component';
import { EditDetailComponent } from './pages/edit-detail/edit-detail.component';
import { CategoryService } from '../category/services/category.service';

const routes: Routes = [
  { path: "", component: ListComponent, canActivate: [canActivate] },
  { path: "detail/:id", component: DetailComponent, canActivate: [canActivate] },
  { path: "category-of-content/:id", component: CategoryOfContentComponent, canActivate: [canActivate] },
  { path: "new", component: NewComponent, canActivate: [canActivate] },
  { path: "edit", component: EditComponent, canActivate: [canActivate] },
  { path: "edit-detail/:id", component: EditDetailComponent, canActivate: [canActivate] },
];


@NgModule({
  declarations: [
    ListComponent,
    DetailComponent,
    CategoryOfContentComponent,
    NewComponent,
    EditComponent,
    EditDetailComponent
  ],
  imports: [
    CommonModule,
    PrimengModule,
    RouterModule.forChild(routes)
  ],
  providers:[
    CategoryService
  ]
})
export class ContentModule { }
