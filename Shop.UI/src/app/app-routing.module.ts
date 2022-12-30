import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './auth/login.component';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { CategoryComponent } from './category/category.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { RegisterComponent } from './register/register.component';
import { CreateOrderComponent } from './create-order/create-order.component';
import { ProductDetailComponent } from './product-list/product-detail/product-detail.component';

const routes: Routes = [
  {path: '', redirectTo: 'product-list', pathMatch:'full'},
  {path: 'product-list', component: ProductListComponent},
  {path: 'product-list/:id', component: ProductDetailComponent},
  {path: "login", component: LoginComponent},
  {path: 'category/:id', component: CategoryComponent},
  {path: 'shoppingCart', component: ShoppingCartComponent},
  {path: 'register', component: RegisterComponent},
  {path : "createOrder", component : CreateOrderComponent}
  
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
