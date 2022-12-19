import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { CategoryComponent } from './category/category.component';

const routes: Routes = [
  {path: '', redirectTo: 'start', pathMatch:'full'},
  {path: "login", component: LoginComponent},
  {path: 'start', component: ProductListComponent},
  {path: 'category/:id', component: CategoryComponent}
  
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
