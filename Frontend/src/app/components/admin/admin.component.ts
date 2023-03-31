import { Component, OnInit } from '@angular/core';
import { Category } from 'src/assets/category';
import { HttpService } from 'src/Services/http.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  categoryTable: Category[] = [];
  tableNames = Category.List;

  constructor(private http: HttpService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(): void {
    this.http.getCategories().then(categories => {
      this.categoryTable = categories;
    });
  }
}
