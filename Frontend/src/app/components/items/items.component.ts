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
  items: Item[] = [];
  itemsFields = Item.List;

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
    
  }
}
