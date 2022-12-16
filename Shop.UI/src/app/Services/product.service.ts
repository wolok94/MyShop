import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { ProductModel } from '../Models/product.model';
import { ProductPagedResultModel } from '../Models/product_paged_result.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  fetchProducts(){
    return this.http.get<ProductPagedResultModel>("https://localhost:63150/api/Product");
    
  }
}
