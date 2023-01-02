import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Subject } from 'rxjs';
import { AddressModel } from '../Models/address.model';
import { OrderModel } from '../Models/order.model';
import { RoleModel } from '../Models/role.model';
import { ShoppingCartModel } from '../Models/shopping-cart.model';
import { UserModel } from '../Models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userSubject = new BehaviorSubject<UserModel>(null);
  user : UserModel;
  isLoged = new BehaviorSubject<boolean>(false);
  constructor(private httpClient: HttpClient, private router:Router) { }


  get token(){
    return localStorage.getItem('token');
  }

  autoLogin(){
    const user : {    id : number;
      email : string;
      nickName : string;
      address : AddressModel;
      addressId : number;
      role : RoleModel;
      roleId : number;
      firstName : string;
      lastName : string;
      orders : OrderModel[];
      shoppingCart : ShoppingCartModel;} = JSON.parse(localStorage.getItem('user'));

      if(!user){
        return;
      }

      this.user = user;
      this.userSubject.next(this.user);
      this.isLoged.next(true);
  }

  logIn(nickName:string, password:string){
    return this.httpClient.post("https://localhost:63150/api/Customer/login", {nickName, password}, {responseType: 'text'})
    .subscribe(response => {
      if (response)
      {
        localStorage.setItem('token',response);
        this.router.navigate(['']);
        this.getUserByNickName(nickName).subscribe(res => {
          this.user = res;
          this.userSubject.next(this.user);
          this.isLoged.next(true);
          localStorage.setItem("user", JSON.stringify(this.user));
        });
      }

    });
  }
  getUserByNickName(nickName:string){
    return this.httpClient.get<UserModel>("https://localhost:63150/api/customer/"+nickName);
  }
  logout(){
    this.user = null;
    this.userSubject.next(null);
    this.isLoged.next(false);
    localStorage.removeItem("token");
    localStorage.removeItem("user");

  }



  

}
