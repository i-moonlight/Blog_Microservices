import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContentService } from '../../services/content.service';
import { ContentDto } from '../../models/contentDto';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  contentId!: string;
  contentDto: ContentDto = new ContentDto();

  constructor(private contentService: ContentService, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
      var id = p["id"]
      this.contentService.contentDetaild(id).subscribe(rv => {
        this.contentDto = rv.data;
      })
    })

  }

}
