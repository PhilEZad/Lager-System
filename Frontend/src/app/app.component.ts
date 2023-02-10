import { Component } from '@angular/core';
import {HttpService} from "../Services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(public http: HttpService) {}
  title = 'Frontend';
  Items: any[] = [];
  itemId: number = 0;
  itemName: string = "";

  print() {
   this.Items = this.http.getItems();
   console.log(this.Items);
  }
}
