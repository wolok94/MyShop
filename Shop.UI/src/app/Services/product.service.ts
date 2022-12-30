import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Subject } from 'rxjs';
import { ProductModel } from '../Models/product.model';
import { ProductPagedResultModel } from '../Models/product_paged_result.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  product = new Subject<ProductModel>();
  loadedProduct : ProductModel;
  constructor(private http:HttpClient) {
    this.product.subscribe(res => {
      this.loadedProduct = res;
    })
   }

  fetchProducts(){
    return this.http.get<ProductPagedResultModel>("https://localhost:63150/api/Product");
    
  }
  fetchProductById(id : number){
    return this.http.get<ProductModel>(`https://localhost:63150/api/Product/`+id);
  }
}
