import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { map } from 'rxjs';
import { CategoryModel } from '../Models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  fetchCategories(){
    return this.http.get<{[key:string]: CategoryModel}>("https://localhost:63150/api/Category").pipe(
      map(responseData => {
      const categoryArray = [];
      for (const key in responseData){
        if(responseData.hasOwnProperty(key)){
          categoryArray.push({...responseData[key], id:  key })
        }
      }
      return categoryArray;
    }));
  }
}
