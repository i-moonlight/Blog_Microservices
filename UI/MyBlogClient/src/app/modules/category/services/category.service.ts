import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReturnObject } from 'src/app/core/models/returnObject';
import { HttpHelperService } from 'src/app/core/services/app.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpHelperService:HttpHelperService) { }

  categories():Observable<ReturnObject>{
    return this.httpHelperService.get("category/category/getall")
  }
}
