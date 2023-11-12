import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../services/content.service';
import { ContentDto } from '../../models/contentDto';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  contentDtos: ContentDto[] = []

  constructor(private contentService: ContentService) {

  }

  ngOnInit(): void {
    this.contentService.contents().subscribe(rv => {
      this.contentDtos = rv.data
      console.log(this.contentDtos)
    })
  }

}
