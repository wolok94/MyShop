import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ProductModel } from '../Models/product.model';
import { ProductCartModel } from '../Models/productCart.model';
import { ShoppingCartModel } from '../Models/shopping-cart.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  loadedShoppingCart: ShoppingCartModel;
  addCountOfProducts = new Subject<ProductModel>();


  constructor(private httpClient: HttpClient) { }

  addProductToShoppingCart(product: ProductModel, quantity:number){
    return this.httpClient.patch("https://localhost:63150/api/basket", {product, quantity})
  }

  fetchShoppingCart(){
    return this.httpClient.get<ShoppingCartModel>("https://localhost:63150/api/Basket")
  }

  deleteProductFromShoppingCart(product: ProductModel){
    return this.httpClient.delete("https://localhost:63150/api/Basket", {body: {product}});
  }
  fetchProductIds(shoppingCartId : number){
    return this.httpClient.get<ProductCartModel[]>("https://localhost:63150/api/ProductCart/"+shoppingCartId);
  }

}
