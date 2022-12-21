import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { CategoryModel } from '../Models/category.model';
import { CategoryService } from '../Services/category.service';
import { ShoppingCartService } from '../Services/shopping-cart.service';
import { ShoppingCartComponent } from '../shopping-cart/shopping-cart.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  loadedCategories: CategoryModel[];
  constructor(private categoryService: CategoryService, private router: Router,
    private shoppingCartService: ShoppingCartService) { }

  ngOnInit(): void {
    this.categoryService.fetchCategories().subscribe(categories => {
      this.loadedCategories = categories;
        
      })
    }

    onLogin(){
      this.router.navigate(['login']);
    }
    clickedCategory(chosenCategory: CategoryModel){
      this.router.navigate(['category/' + chosenCategory.categoryId]);
    }
    shoppingCartClicked(){
      this.router.navigate(['shoppingCart']);
    }
    get numberOfProducts(){
      return this.shoppingCartService.loadedShoppingCart.products.length;
    }
  }

