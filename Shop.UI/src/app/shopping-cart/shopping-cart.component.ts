import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductModel } from '../Models/product.model';
import { ShoppingCartModel } from '../Models/shopping-cart.model';
import { AuthService } from '../Services/auth.service';
import { ShoppingCartService } from '../Services/shopping-cart.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  products: ProductModel[];
  constructor(private shoppingCartService: ShoppingCartService, private router: Router
    ,private authService : AuthService) { 

  }

  ngOnInit(): void {
    this.shoppingCartService.fetchShoppingCart()
    .subscribe(shoppingCart => {
      this.shoppingCartService.loadedShoppingCart = shoppingCart;
      this.products = shoppingCart.products;
      this.authService.user.shoppingCart = this.shoppingCart;
      this.authService.userSubject.next(this.authService.user);
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
        let index = this.authService.user.shoppingCart.products
        .findIndex(x => x.title === product.title);
        this.authService.user.shoppingCart.products.splice(index,1);
        this.authService.userSubject.next(this.authService.user);
        this.ngOnInit();
      })
  }
  order(){
    this.router.navigate(["createOrder"]);
  }

}
