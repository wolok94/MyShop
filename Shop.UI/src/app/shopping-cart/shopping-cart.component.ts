import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../Models/product.model';
import { ShoppingCartModel } from '../Models/shopping-cart.model';
import { ShoppingCartService } from '../Services/shopping-cart.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  products: ProductModel[];
  constructor(private shoppingCartService: ShoppingCartService) { 

  }

  ngOnInit(): void {
    this.shoppingCartService.fetchShoppingCart()
    .subscribe(shoppingCart => {
      this.shoppingCartService.loadedShoppingCart = shoppingCart;
      this.products = shoppingCart.products;
    })

  }

  priceOfOrder(){
    let price = 0;
    for(let product of this.products){
      price += product.price;
    }
    return price;
  }

  get shoppingCart(){
    return this.shoppingCartService.loadedShoppingCart;
  }
  deleteProductFromShoppingCart(product: ProductModel){
    this.shoppingCartService.deleteProductFromShoppingCart(product)
      .subscribe(response => {
        console.log(response);
        this.ngOnInit();
      })
  }

}
