import { Component, OnInit } from '@angular/core';
import { Item } from 'src/assets/item';
import { HttpService } from 'src/Services/http.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit {
  
  constructor(private http: HttpService) { }
  
  items: any[] = [];
  title = "Items list";
  
  ngOnInit(): void {
    this.getItems();
  }

  getItems(): void {
    this.items = this.http.getItems();
  }
}
