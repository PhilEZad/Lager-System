import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/assets/item';
import { HttpService } from 'src/Services/http.service';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit {
  location: any;
  
  constructor(
    private route: ActivatedRoute,
    private http: HttpService
    ) { }
    
    @Input() item?: Item;
    
    ngOnInit(): void {
      this.getItem();
    }
    
    getItem(): void {
      const id = Number(this.route.snapshot.paramMap.get('id'));
      this.http.getItem(id).then(item => {
        this.item = item;
      });

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
}
