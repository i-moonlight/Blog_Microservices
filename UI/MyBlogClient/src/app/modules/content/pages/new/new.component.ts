import { Component, OnInit } from '@angular/core';
import { ContentCreateDto } from '../../models/contentCreateDto';
import { ContentService } from '../../services/content.service';
import { MenuItem } from 'primeng/api';
import { ContentUpdateDto } from '../../models/contentUpdateDto';
import { CategoryService } from 'src/app/modules/category/services/category.service';
import { CategoryDto } from 'src/app/modules/category/models/categoryDto';

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

  items: MenuItem[] | undefined;
  activeIndex: number = 0;

  contentId!: string;
  imageUrl!: string;
  categories: CategoryDto[] = [];
  category: CategoryDto = new CategoryDto();

  constructor(private contentService: ContentService, private categoryService: CategoryService) {

  }

  ngOnInit(): void {

    this.items = [
      { label: 'Add Content', command: (event: any) => { } },
      { label: 'Add Content Page Image', command: (event: any) => { } },
      { label: 'Complete', command: (event: any) => { } },
    ];

    this.categoryService.categories().subscribe(rv => {
      this.categories = rv.data;
      // this.category = this.categories[0]
    })
  }

  onUpload(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      this.contentDto.image = file;
      this.fileName = file.name;

      const formData = new FormData();
      formData.append("thumbnail", file);

      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]);
      reader.onload = (_event) => {
        this.msg = "";
        this.url = reader.result;
      }
    }
  }

  createContent() {
    console.log(this.category)
    this.contentDto.categoryId = this.category.id;
    this.contentDto.user = this.contentService.getUser();
    this.contentService.createContent(this.contentDto).subscribe(rv => {
      this.contentId = rv.data
    })
  }
  updateContent() {
    let updateContent: ContentUpdateDto = { ...this.contentDto, id: this.contentId, imageUrl: this.imageUrl };
    this.contentService.updateContent(updateContent).subscribe(rv => {

    });
  }

  uploadImage() {
    const formData: FormData = new FormData();
    formData.append('file', this.contentDto.image, this.contentDto.image.name);
    this.contentService.upload(formData).subscribe(rv => {
      this.imageUrl = rv.data;
      if (this.imageUrl != "") {
        this.updateContent();
      }
    })
  }

  onActiveIndexChange(event: number) {
    // this.activeIndex = event;
  }

  next(step: number) {

    this.activeIndex = step;

    if (this.activeIndex == 1) {
      this.createContent();
    }
    else if (this.activeIndex == 2) {
      this.uploadImage();
    }

  }


}
