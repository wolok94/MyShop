import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ProductModel } from 'src/app/Models/product.model';
import { ProductService } from 'src/app/Services/product.service';
import { ShoppingCartService } from 'src/app/Services/shopping-cart.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit, OnDestroy {
  product: ProductModel;
  productSubscription : Subscription;
  isLoged : boolean;
  constructor(private productService : ProductService, private shoppingCartService: ShoppingCartService) { 
    if(this.product === undefined)
    {
    this.productSubscription = this.productService.product.subscribe(loadedProduct => {
      this.product = loadedProduct;
    });
    };
  }
  ngOnDestroy(): void {
    this.productSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.isLoged = localStorage.getItem('isLoged') === 'true';
  }
  buyProduct(){
    this.shoppingCartService.addProductToShoppingCart(this.product).subscribe(response => {
      console.log(response);
      this.shoppingCartService.addCountOfProducts.next(this.product);
    });
  }
  }

