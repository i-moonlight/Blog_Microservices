import { Injectable } from '@angular/core';
import { HttpHelperService } from 'src/app/core/services/app.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpHelperService:HttpHelperService) { }

  categories(){
    return this.httpHelperService.get("category/category/GetAll")
  }
}
