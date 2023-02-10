import { Injectable } from '@angular/core';
import axios from "axios";
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from "@angular/router";

export const customAxios = axios.create({
  baseURL: 'http://localhost:7077'
})
@Injectable({
  providedIn: 'root'
})

export class HttpService {
  items: Items[] = [];
  constructor() { }

  getItems(){
    customAxios.get<Items>('api/item').then(succes => {
      console.log(succes);
       return succes.data;
    }).catch(e=>{
      console.log(e);
      return null;
    })
    console.log("execute");
    return null;
  }

  async addItem(dto: { Name: string }) {
    const httpResult = await customAxios.post<Items>('api/item', dto);
    this.items.push(httpResult.data)
  }

}
interface Items {
  id: number,
  name: string
}


@Injectable({providedIn: 'root'})
export class MyResolver implements Resolve<any> {
  constructor(private http: HttpService) {
  }

//resolve is used on line 30 in app modulle. Resolve er den fetcher data uden refresh
  async resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<any> {
    await this.http.getItems();
    return true;
  }
}
