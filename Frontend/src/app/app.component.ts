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
//used propertys for adding pets
  itemId: number = 0;
  itemName: string = "";

}
