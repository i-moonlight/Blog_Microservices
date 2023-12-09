import { Component, OnInit } from '@angular/core';
import { ContentDto } from '../../models/contentDto';
import { ContentService } from '../../services/content.service';
import { ActivatedRoute } from '@angular/router';
import { ContentUpdateDto } from '../../models/contentUpdateDto';

@Component({
  selector: 'app-edit-detail',
  templateUrl: './edit-detail.component.html',
  styleUrls: ['./edit-detail.component.css']
})
export class EditDetailComponent implements OnInit {

  contentDto: ContentDto = new ContentDto();
  imageUrl!: any;
  newImage!: File
  contentId!: string;
  constructor(private contentService: ContentService, private route: ActivatedRoute) {


  }

  ngOnInit(): void {
    this.route.params.subscribe((p) => {
      this.contentId = p["id"];
      this.contentService.contentDetaild(this.contentId).subscribe((rv) => {
        this.contentDto = rv.data;
        this.imageUrl = this.contentDto.imageUrl;
      });
    });
  }

  onUpload(event: any) {
    this.newImage = event.target.files[0];

    if (this.newImage) {
      var reader = new FileReader();
      reader.readAsDataURL(this.newImage);
      reader.onload = (_event) => {
        this.imageUrl = reader.result;
      }
    }
  }

  update() {

    if (this.newImage == undefined) {
      this.updateContent()
    } else {
      this.uploadImage()
    }
  }

  uploadImage() {
    const formData: FormData = new FormData();
    formData.append('file', this.newImage, this.newImage.name);
    this.contentService.upload(formData).subscribe(rv => {
      this.imageUrl = rv.data;
      if (this.imageUrl != "") {
        this.updateContent();
      }
    })
  }

  updateContent() {
    let updateContent: ContentUpdateDto = { ...this.contentDto, id: this.contentId, imageUrl: this.imageUrl };
    this.contentService.updateContent(updateContent).subscribe(rv => {

    });
  }
}
