import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';
import { ButtonModule } from 'primeng/button';
import { InputSwitchModule } from 'primeng/inputswitch';
import { RippleModule } from 'primeng/ripple';
import { MessagesModule } from 'primeng/messages';
import { TooltipModule } from 'primeng/tooltip';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { CheckboxModule } from 'primeng/checkbox';
import { ToastModule } from 'primeng/toast';
import { MenuModule } from 'primeng/menu';
import { DividerModule } from 'primeng/divider';
import { TableModule } from 'primeng/table';
import { PaginatorModule } from 'primeng/paginator';
import { ProgressBarModule } from 'primeng/progressbar';
import { DialogModule } from 'primeng/dialog';
import { FileUploadModule } from 'primeng/fileupload';
import { StepsModule } from 'primeng/steps';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports:[
    InputTextModule,
    SidebarModule,
    InputSwitchModule,
    RippleModule,
    MessagesModule,
    ButtonModule,
    TooltipModule,
    OverlayPanelModule,
    CardModule,
    DropdownModule,
    InputTextareaModule,
    CheckboxModule,
    ToastModule,
    MenuModule,
    DividerModule,
    TableModule,
    PaginatorModule,
    ProgressBarModule,
    DialogModule,
    FileUploadModule,
    StepsModule
  ]
})
export class PrimengModule { }
