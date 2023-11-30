import { Component, OnInit } from '@angular/core';
import { ContentCreateDto } from '../../models/contentCreateDto';
import { ContentService } from '../../services/content.service';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {

  contentDto: ContentCreateDto = new ContentCreateDto();
  fileName: string = ''



  url: any;
  msg = "";

  constructor(private contentService:ContentService) {
    
  }

  ngOnInit(): void {

  }

  onUpload(event: any) {
    console.log(event)
    const file: File = event.target.files[0];

    if (file) {
      this.contentDto.image = file;
      this.fileName = file.name;

      const formData = new FormData();

      formData.append("thumbnail", file);
      console.log(formData)


      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]);
      reader.onload = (_event) => {
        this.msg = "";
        this.url = reader.result;
      }
    }
  }
  save() {
    this.contentDto.categoryId = "65554bb9234048202cda61e9";
    this.contentDto.user = this.contentService.getUser();

    const formData: FormData = new FormData();
    formData.append('title', this.contentDto.title);
    formData.append('text', this.contentDto.text);
    formData.append('categoryId', this.contentDto.categoryId);
    formData.append('User.Id', this.contentDto.user.id);
    formData.append('User.Username', this.contentDto.user.username);
    formData.append('image', this.contentDto.image, this.contentDto.image.name);


    console.log(formData)
    this.contentService.createContent(formData).subscribe(rv=>{
    console.log(rv);
    })
  }

}
