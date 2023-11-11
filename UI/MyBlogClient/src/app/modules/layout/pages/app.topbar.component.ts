import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from '../services/layout.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html'
})
export class AppTopBarComponent implements OnInit {

    items!: MenuItem[];
  
    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    loginCheck:boolean=false
    constructor(public layoutService: LayoutService,private router:Router) { }

    ngOnInit() {
        
    }

    signOut() {
        localStorage.setItem("user","")
        this.router.navigateByUrl("/auth/login")
    }

    signIn() {
        this.router.navigateByUrl("/auth/login")
    }
}
