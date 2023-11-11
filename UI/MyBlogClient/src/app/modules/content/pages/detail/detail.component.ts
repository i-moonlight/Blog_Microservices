import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ContentService } from "../../services/content.service";
import { ContentDto } from "../../models/contentDto";
import { CommentDto } from "../../models/commentDto";

@Component({
  selector: "app-detail",
  templateUrl: "./detail.component.html",
  styleUrls: ["./detail.component.css"],
})
export class DetailComponent implements OnInit {
  contentId!: string;
  contentDto: ContentDto = new ContentDto();
  comment!: string;
  commentDtos: CommentDto[] = [];

  constructor(
    private contentService: ContentService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((p) => {
      var id = p["id"];
      this.contentService.contentDetaild(id).subscribe((rv) => {
        this.contentDto = rv.data;
        this.comments();
      });
    });
  }

  like() {
    console.log("like");
  }
  sendCommend() {
    var comment: CommentDto = new CommentDto();
    comment.contentId = this.contentDto.id;
    comment.text = this.comment;
    comment.user = this.contentService.getUser();
    
    this.contentService.sendComment(comment).subscribe((rv) => {
      this.commentDtos.push(comment)
    });
  }

  comments() {
    this.contentService.comments(this.contentDto.id).subscribe((rv) => {
      this.commentDtos = rv.data;

    });
  }
}
