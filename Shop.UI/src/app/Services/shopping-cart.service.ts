import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductModel } from '../Models/product.model';
import { ShoppingCartModel } from '../Models/shopping-cart.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  constructor(private httpClient: HttpClient, private auth:AuthService) { }

  addProductToShoppingCart(product: ProductModel){
    const json = JSON.stringify(product);
    return this.httpClient.patch("https://localhost:63150/api/basket", json
    , {headers: new HttpHeaders({"Authorization": "Bearer "+this.auth.response})});
  }

  fetchShoppingCart(){
    return this.httpClient.get<ShoppingCartModel>("https://localhost:63150/api/Basket",
    {headers: new HttpHeaders({"Authorization": "Bearer "+this.auth.response})});
  }
}
