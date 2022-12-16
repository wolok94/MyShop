import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../Models/product.model';
import { ProductPagedResultModel } from '../Models/product_paged_result.model';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  loadedProducts: ProductModel[] = [];
  productPagedResultProducts: ProductPagedResultModel;
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.fetchProducts().subscribe(products => {
      this.productPagedResultProducts = products;
      this.loadedProducts = this.productPagedResultProducts['items'];
    })}

}
