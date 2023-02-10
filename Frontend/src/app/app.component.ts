import { Component } from '@angular/core';
import {HttpService} from "../Services/http.service";
import * as http from "http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private http: HttpService) {}
  title = 'Frontend';
  Items: any[] = [];
  itemId: number = 0;
  itemName: string = "";

  print() {
   this.Items = this.http.getItems();
   console.log(this.Items);
  }

  addItem() {
    this.http.addItem({Name : this.itemName});
  }
}
