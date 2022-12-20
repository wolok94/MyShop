import { Component, OnInit } from '@angular/core';
import { ShoppingCartModel } from '../Models/shopping-cart.model';
import { ShoppingCartService } from '../Services/shopping-cart.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  loadedShoppingCart: ShoppingCartModel;
  constructor(private shoppingCartService: ShoppingCartService) { }

  ngOnInit(): void {
    this.shoppingCartService.fetchShoppingCart()
      .subscribe(shoppingCart => {
        this.loadedShoppingCart = shoppingCart;
      })
  }

}
