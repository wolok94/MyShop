import { Component, OnDestroy, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Subject, Subscription } from 'rxjs';
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
export class HeaderComponent implements OnInit, OnDestroy {
  loadedCategories: CategoryModel[];
  isLoged : boolean;
  userSub = new Subscription;
  productSub = new Subscription;
  constructor(private categoryService: CategoryService, private router: Router,
    private shoppingCartService: ShoppingCartService, private authService : AuthService) { }
  ngOnDestroy(): void {
    this.userSub.unsubscribe();
    this.productSub.unsubscribe();
  }

  ngOnInit(): void {
    this.categoryService.fetchCategories().subscribe(categories => {
      this.loadedCategories = categories;
        
      });
      this.authService.isLoged.subscribe(res => {
        this.isLoged = res;
      })
      this.productSub = this.shoppingCartService.addCountOfProducts.subscribe(res => {
        this.shoppingCartService.loadedShoppingCart.products.push(res);
      })
      this.userSub = this.authService.userSubject.subscribe(res => {
        this.shoppingCartService.loadedShoppingCart = res['shoppingCart'];
      });
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
    getNumberOfProducts(){

        if(this.isLoged && this.shoppingCartService.loadedShoppingCart != undefined)
        {
        return this.shoppingCartService.loadedShoppingCart.products.length
        // this.shoppingCartService.loadedShoppingCart.products.reduce((sum, current) => sum + current.numberOfProducts, 0);
        


        }
        else
        return 0;

    }
    logout(){
      this.authService.logout();
      this.router.navigate(['login']);
    }


  }

