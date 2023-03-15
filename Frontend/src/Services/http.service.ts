import { Injectable } from '@angular/core';
import axios from "axios";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Item } from 'src/assets/item';
import { Category } from 'src/assets/category';

export const customAxios = axios.create({
  baseURL: 'http://localhost:8080'
})
@Injectable({
  providedIn: 'root'
})

export class HttpService {
  items: Item[] = [];
  constructor() { }
  
  public async getItems(): Promise<Item[]> {
    try {
      const response = await customAxios.get<Item[]>('api/item');
      console.log(response);
      return response.data;
    } catch (error) {
      console.log(error);
      return [];
    }
  }
  
  public async getCategories(): Promise<Category[]> {
    try {
      const response = await customAxios.get<Category[]>('api/category');
      console.log(response);
      return response.data;
    } catch (error) {
      console.log(error);
      return [];
    }
  }

  public async addItem(item: Item) {
    const httpResult = await customAxios.post<Item>('api/item', item);
    this.items.push(httpResult.data);
  }

  public async deleteItem(id: number): Promise<Item> {
    try {
      const response = await customAxios.delete(`api/item/deleteItem${id}`);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

  public async getItem(id: number): Promise<Item> {
    try {
      const response = await customAxios.get<Item>(`api/item/${id}`);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
  public async editItem(item: Item): Promise<Item> {
    try {
      const response = await customAxios.put<Item>(`api/item/`, item);
      return response.data;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

}


@Injectable({ providedIn: 'root' })
export class MyResolver implements Resolve<any> {
  constructor(private http: HttpService) {
  }

  //resolve is used on line 30 in app modulle. Resolve er den fetcher data uden refresh
  async resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<any> {
    await this.http.getItems();
    return true;
  }
}
