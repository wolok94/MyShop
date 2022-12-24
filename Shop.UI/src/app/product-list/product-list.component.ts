import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderComponent } from '../header/header.component';
import { ProductModel } from '../Models/product.model';
import { ProductPagedResultModel } from '../Models/product_paged_result.model';
import { ProductService } from '../Services/product.service';
import { ShoppingCartService } from '../Services/shopping-cart.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  loadedProducts: ProductModel[] = [];
  productPagedResultProducts: ProductPagedResultModel;
  constructor(private productService: ProductService, private shoppingCartService: ShoppingCartService) { }

  ngOnInit(): void {
    this.productService.fetchProducts().subscribe(products => {
      this.productPagedResultProducts = products;
      this.loadedProducts = this.productPagedResultProducts['items'];
    })}

    onBuyClick(product: ProductModel){
      this.shoppingCartService.addProductToShoppingCart(product).subscribe(response => {
        this.productService.setCountOfProducts(1);
        console.log(response);
      });
    }
}
