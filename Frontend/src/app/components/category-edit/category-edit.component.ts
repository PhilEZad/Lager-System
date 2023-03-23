import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Category } from 'src/assets/category';
import { HttpService } from 'src/Services/http.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.scss']
})
export class CategoryEditComponent implements OnInit {

  @Input() category!: Category;

  constructor(
    private route: ActivatedRoute,
    private http: HttpService,
    private location: Location,
    ) { }

  ngOnInit(): void {
    this.getCategory();
  }

  getCategory(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.http.getCategory(id).then(category => {
      this.category = category;
    });
  }

  deleteCategory() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.http.deleteCategory(id).then(category => {
      this.category = category;
      this.goBack();
    });
  }

  goBack() {
    this.location.back();
  }

  editCategory() {
    this.http.editCategory(this.category).then(category => {
      this.category = category;
    });
  }

}
