import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
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
  numberOfPages : number;
  pages : number[] = [];
  currentPage : number = 1;

  constructor(private productService: ProductService, private shoppingCartService: ShoppingCartService,
    private route:Router, private activatedRoute: ActivatedRoute) {


     }

  ngOnInit(): void {
    this.productService.fetchProducts(1).subscribe(products => {
      this.productPagedResultProducts = products;
      this.loadedProducts = this.productPagedResultProducts['items'];
      this.numberOfPages = products['totalPages'];
      for (let i = 1; i <= this.numberOfPages; i++) {
        this.pages.push(i);
        
      };
    })};


 


    clickedProduct(id: number, product:ProductModel){
      this.productService.fetchProductById(product.id).subscribe(res => {
        this.productService.product.next(res);
      })
      this.route.navigate([id], {relativeTo: this.activatedRoute});

    }
    fetchProducts(page : number){
      this.productService.fetchProducts(page).subscribe(products => {
        this.productPagedResultProducts = products;
        this.loadedProducts = this.productPagedResultProducts['items'];
        this.numberOfPages = products['totalPages'];
      });
      this.currentPage = page;
    }
}
