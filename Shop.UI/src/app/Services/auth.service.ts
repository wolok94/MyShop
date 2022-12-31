import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { UserModel } from '../Models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userSubject = new Subject<UserModel>();
  user : UserModel;
  isLoged = new Subject<boolean>();
  constructor(private httpClient: HttpClient, private router:Router) { }


  get token(){
    return localStorage.getItem('token');
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

  }



  

}
