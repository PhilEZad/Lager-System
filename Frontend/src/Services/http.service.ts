import { Injectable } from '@angular/core';
import axios from "axios";

@Injectable({
  providedIn: 'root'
})
export const customAxios = axios.create({
  baseURL: 'http://localhost:7077'
})
export class HttpService {
  constructor() { }

  getItems(){
    customAxios.get<String>('api/item').then(succes => {
      console.log(succes);
       return succes.data;
    }).catch(e=>{
      console.log(e);
      return null;
    })
    console.log("execute");
    return null;
  }
}
