import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppSidebarComponent } from './pages/app.sidebar.component';
import { AppTopBarComponent } from './pages/app.topbar.component';
import { AppMenuitemComponent } from './pages/app.menuitem.component';
import { AppMenuComponent } from './pages/app.menu.component';
import { AppLayoutComponent } from './pages/app.layout.component';
import { AppFooterComponent } from './pages/app.footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { PrimengModule } from '../primeng/primeng.module';
import { CategoryModule } from '../category/category.module';

@NgModule({
  declarations: [
    AppSidebarComponent,
    AppTopBarComponent,
    AppMenuitemComponent,
    AppMenuComponent,
    AppLayoutComponent,
    AppFooterComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule,
    PrimengModule,
  ],
  exports:[
    AppLayoutComponent
  ]
})
export class LayoutModule { }
