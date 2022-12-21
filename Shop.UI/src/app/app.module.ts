import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ProductListComponent } from './product-list/product-list.component';
import { LoginComponent } from './auth/login.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { CategoryComponent } from './category/category.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { TokenInterceptorService } from './Services/token-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProductListComponent,
    LoginComponent,
    CategoryComponent,
    ShoppingCartComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, FormsModule
  ],
  providers: [{provide:HTTP_INTERCEPTORS,useClass:TokenInterceptorService,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
