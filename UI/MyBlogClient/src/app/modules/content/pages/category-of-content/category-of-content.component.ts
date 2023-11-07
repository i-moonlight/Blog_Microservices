import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../services/content.service';
import { ActivatedRoute } from '@angular/router';
import { ContentDto } from '../../models/contentDto';

@Component({
  selector: 'app-category-of-content',
  templateUrl: './category-of-content.component.html',
  styleUrls: ['./category-of-content.component.css']
})
export class CategoryOfContentComponent implements OnInit {
  contentId!: string;
  contentDtos: ContentDto[] = []
  constructor(private contentService: ContentService, private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.route.params.subscribe(p => {
      var id = p["id"]
      this.contentService.contentByCategoryId(id).subscribe(rv => {
        this.contentDtos = rv.data;
      })

    })
  }

}
