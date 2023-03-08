import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  title = "Items list";
  items: Item[] = [];
  name: string = "";

  ngOnInit(): void {
    this.getItems();
  }

  onSelect(_item: Item): void {
    this.selectedItem = _item;
  }

  getItems(): void {
    this.http.getItems().then(items => {
      this.items = items;
    });
  }

  addItem(): void {
    let item = new Item(0, this.name);
    this.http.addItem(item).then(itmes => {
      this.getItems();
    });
  }
}
