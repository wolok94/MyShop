import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryModel } from '../Models/category.model';
import { ProductModel } from '../Models/product.model';
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit{
  categoryId: number;
  chosenCategory: CategoryModel;
  products: ProductModel[];
  subscription: Subscription;
  constructor(private categoryService: CategoryService, private activatedRoute: ActivatedRoute) { }


  ngOnInit(): void {
    this.activatedRoute.params
      .subscribe(params => {
        this.categoryId = params['id'];
      })
    this.subscription = this.categoryService.fetchCategory(this.categoryId)
      .subscribe(response => {
        this.products = response['products'];
        this.ngOnInit();
      });
  }





}
