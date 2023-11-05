import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from '../services/layout.service';
import { CategoryService } from '../../category/services/category.service';
import { ReturnObject } from 'src/app/core/models/returnObject';
import { CategoryDto } from '../../category/models/categoryDto';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    menus: any[] = [];
    categories:CategoryDto[]=[];
    constructor(public layoutService: LayoutService,private categoryService:CategoryService) { }

    ngOnInit() {
        
        var newMenuItems:NewMenuItem[]=[];
        this.categoryService.categories().subscribe(rv=>{
            
            this.categories=rv.data;

            this.categories.forEach(element => {
                var newMenuItem:NewMenuItem=new NewMenuItem();
                newMenuItem.label=element.name
                newMenuItem.routerLink=element.name
                newMenuItem.icon="pi pi-fw pi-angle-right"
                newMenuItems.push(newMenuItem)
            });

        })
        


        this.menus = [
            {
                label: 'Categories',
                items: newMenuItems
            }
        ]
    } 
}

export class NewMenu{

    label!:string
    items!:NewMenuItem[]
}

export class NewMenuItem{
    label!:string
    icon!:string
    routerLink!:string
}

