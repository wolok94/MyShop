import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductModel } from '../Models/product.model';
import { ShoppingCartModel } from '../Models/shopping-cart.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  loadedShoppingCart: ShoppingCartModel;
  constructor(private httpClient: HttpClient, private auth:AuthService) { }

  addProductToShoppingCart(product: ProductModel){
    return this.httpClient.patch("https://localhost:63150/api/basket", {product})
  }

  fetchShoppingCart(){
    return this.httpClient.get<ShoppingCartModel>("https://localhost:63150/api/Basket")
  }

  deleteProductFromShoppingCart(product: ProductModel){
    return this.httpClient.delete("https://localhost:63150/api/Basket", {body: {product}});
  }
}
