import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  error = new Subject<string>();

  constructor(private httpClient: HttpClient) { }

  logIn(nickName:string, password:string){
    this.httpClient.post("https://localhost:63150/api/Customer/login", {nickName, password})
    .subscribe(response => {
      console.log(response);
    })
  }
}
