import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { LoginComponent } from '../auth/login.component';
import { CategoryModel } from '../Models/category.model';
import { AuthService } from '../Services/auth.service';
import { CategoryService } from '../Services/category.service';
import { ProductService } from '../Services/product.service';
import { ShoppingCartService } from '../Services/shopping-cart.service';
import { ShoppingCartComponent } from '../shopping-cart/shopping-cart.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  loadedCategories: CategoryModel[];
  isLoged : boolean;
  countOfProducts: number = 0;
  constructor(private categoryService: CategoryService, private router: Router,
    private shoppingCartService: ShoppingCartService, private authService : AuthService) { }

  ngOnInit(): void {
    this.categoryService.fetchCategories().subscribe(categories => {
      this.loadedCategories = categories;
        
      });
      this.isLoged = localStorage.getItem("isLoged") == "true";
      
      

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
      
      this.authService.userSubject.subscribe(res => {
        console.log(res['shoppingCart']);
        this.shoppingCartService.loadedShoppingCart = res['shoppingCart'];
      });
        if(this.isLoged && this.shoppingCartService.loadedShoppingCart != undefined)
        {
        return this.shoppingCartService.loadedShoppingCart.products.length

        }
        else
        return 0;

    }


  }

