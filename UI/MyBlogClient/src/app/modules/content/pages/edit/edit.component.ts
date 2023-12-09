import { Component, OnInit } from '@angular/core';
import { ContentDto } from '../../models/contentDto';
import { ContentService } from '../../services/content.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit{
  
  contentDtos: ContentDto[] = []

  constructor(private contentService: ContentService) {
  }

  ngOnInit(): void {
    this.contentService.contents().subscribe(rv => {
      this.contentDtos = rv.data
    })
  }


}
