import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/assets/category';
import { HttpService } from 'src/Services/http.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.scss']
})
export class CategoryAddComponent implements OnInit {

  @Input() category!: Category;

  constructor(
    private route: ActivatedRoute,
    private http: HttpService,
    private location: Location,
  ) { }

  ngOnInit(): void {
    this.category = new Category(0, "");
  }

  goBack() {
    this.location.back();
  }

  add() {
    this.http.addCategory(this.category).then(category => {
      //this.category = category;
      this.location.back();
    });
  }
}
