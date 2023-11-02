import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private categoryService:CategoryService) {
    
    
  }
  
  ngOnInit(): void {
    this.categoryService.categories().subscribe(rv=>{
      console.log(rv)
    })
  }

}
