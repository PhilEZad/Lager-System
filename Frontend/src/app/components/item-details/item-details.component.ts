import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/assets/item';
import { HttpService } from 'src/Services/http.service';
import { Location } from '@angular/common';
import { Category } from 'src/assets/category';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private http: HttpService,
    private location: Location
  ) { }

  categories: Category[] = [];
  @Input() item!: Item;

  ngOnInit(): void {
    this.getItem();
    this.getCategories();
  }

  getItem(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.http.getItem(id).then(item => {
      this.item = item;
    });
  }
  
  getCategories(): void {
    this.http.getCategories().then(categories => {
      this.categories = categories;
    })
  }

  deleteItem(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.http.deleteItem(id).then(item => {
      this.item = item;
      this.goBack();
    });
  }

  goBack() {
    this.location.back();
  }

  editItem() {
    this.http.editItem(this.item).then(item => {
      this.item = item;
    });
  }
}
