import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private responseData: any;
  constructor(private httpClient: HttpClient, private router:Router) { }


  get response(){
    return this.responseData;
  }

  logIn(nickName:string, password:string){
    return this.httpClient.post("https://localhost:63150/api/Customer/login", {nickName, password}, {responseType: 'text'})
    .subscribe(response => {
      if (response)
      {
        this.responseData = response;
        localStorage.setItem('token', this.responseData);
        this.router.navigate(['']);
      }

    });


  }
}
