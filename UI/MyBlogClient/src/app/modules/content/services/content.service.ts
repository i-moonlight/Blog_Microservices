import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReturnObject } from 'src/app/core/models/returnObject';
import { HttpHelperService } from 'src/app/core/services/app.service';
import { CommentDto } from '../models/commentDto';
import { User } from 'src/app/core/models/user';

@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor(private httpHelperService: HttpHelperService) { }

  contents(): Observable<ReturnObject> {
    return this.httpHelperService.get("content/content/getall")
  }

  contentByCategoryId(id: string): Observable<ReturnObject> {
    return this.httpHelperService.get("content/content/GetAllByCategoryName?categoryId=" + id)
  }

  contentDetaild(id: string): Observable<ReturnObject> {
    return this.httpHelperService.get("content/content/GetById?id=" + id)
  }

  sendComment(commentDto: CommentDto) {
    return this.httpHelperService.post("comment/comment/Create", commentDto)
  }

  getUser(){
    return JSON.parse(localStorage.getItem("user")!) as User
  }

}
