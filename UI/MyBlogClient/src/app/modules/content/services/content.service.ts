import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReturnObject } from 'src/app/core/models/returnObject';
import { HttpHelperService } from 'src/app/core/services/app.service';
import { CommentDto } from '../models/commentDto';
import { User } from 'src/app/core/models/user';
import { ContentCreateDto } from '../models/contentCreateDto';
import { LikeDto } from '../models/LikeDto';
import { HttpHeaders } from '@angular/common/http';


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

  sendLike(likeDto: LikeDto) {
    return this.httpHelperService.post("reaction/reaction/like", likeDto)
  }

  getUser(){
    return JSON.parse(localStorage.getItem("user")!) as User
  }

  createContent(content:any){
    const headers = new HttpHeaders({
      'Content-Type': 'multipart/form-data',
      'Accept': 'application/json'
    });
    return this.httpHelperService.post("content/content/create",content,headers);
  }

}
