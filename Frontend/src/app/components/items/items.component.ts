import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/assets/category';
import { Item } from 'src/assets/item';
import { HttpService } from 'src/Services/http.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit {
  
  constructor(private http: HttpService, private route: ActivatedRoute) { }

  selectedItem?: Item;
  items: Item[] = [];
  itemsFields = Item.List;
  categories: Category[] = [];

  categoryName: string = "Hello";

  ngOnInit(): void {
    this.getItems();
    this.getCategories();
  }

  onSelect(_item: Item): void {
    this.selectedItem = _item;
  }

  getItems(): void {
    this.http.getItems().then(items => {
      this.items = items;
    });
  }

  getCategories(): void {
    this.http.getCategories().then(categories => {
      this.categories = categories;
    })
  }

  getCategoryName(_categoryId: number): string {
    //var categoryName = this.categories[_categoryId].categoryName
    var category = this.categories.find(i => i.categoryId == _categoryId);
    if (category != null){
      return category.categoryName
    }
    return "Could not find"
  }

  setCategoryForItem(_item: Item): void {
    var _itemCategory = _item.category;

  }

  addItem(): void {
    
  }
}
