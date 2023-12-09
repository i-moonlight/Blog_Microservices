import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ContentService } from "../../services/content.service";
import { ContentDto } from "../../models/contentDto";
import { CommentDto } from "../../models/commentDto";
import { LikeDto } from "../../models/LikeDto";

@Component({
  selector: "app-detail",
  templateUrl: "./detail.component.html",
  styleUrls: ["./detail.component.css"],
})
export class DetailComponent implements OnInit {
  contentId!: string;
  contentDto: ContentDto = new ContentDto();
  comment!: string;

  constructor(
    private contentService: ContentService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((p) => {
      var id = p["id"];
      this.contentService.contentDetaild(id).subscribe((rv) => {
        this.contentDto = rv.data;
      });
    });
  }

  like() {
    var like=new LikeDto();
    like.contentId=this.contentDto.id;
    like.user=this.contentService.getUser();
    this.contentService.sendLike(like).subscribe(rv=>{
      this.contentDto.likes.push(like);
    })
  }

  sendCommend() {
    var comment: CommentDto = new CommentDto();
    comment.contentId = this.contentDto.id;
    comment.text = this.comment;
    comment.user = this.contentService.getUser();

    this.contentService.sendComment(comment).subscribe((rv) => {
      this.contentDto.comments.push(comment)
    });
  }
}
