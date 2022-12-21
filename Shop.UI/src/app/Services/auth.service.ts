import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

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
      }

    });


  }
}
