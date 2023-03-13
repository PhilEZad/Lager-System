import { Component, Input, OnInit } from '@angular/core';
import { Category } from 'src/assets/category';
import { Item } from 'src/assets/item';
import { Location } from '@angular/common';
import { HttpService } from 'src/Services/http.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.scss']
})
export class AddItemComponent implements OnInit {

  constructor(
    private http: HttpService,
    private location: Location
  ) { }

  categories: Category[] = [];
  @Input() item!: Item;

  ngOnInit(): void {
    this.getCategories();
  }

  goBack() {
    this.location.back();
  }

  addItem(): void {
    //let item = new Item(0, this.item.name, this.item.location, this.item.category, this.item.status);
    this.http.addItem(this.item).then(itemReturn => {
      //this.item = item;
    });
  }

  getCategories(): void {
    this.http.getCategories().then(categories => {
      this.categories = categories;
    })
  }
}
