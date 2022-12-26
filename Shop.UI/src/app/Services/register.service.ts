import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }

  registerUser(firstName : string, lastName : string, email : string,
    nickName : string, password, country : string, city : string,
    street : string, houseNumber :string, postalCode : string ){
    return this.http.post("https://localhost:63150/api/Customer", {firstName, lastName, email, nickName, password,
     "Address" : {country, city, street, houseNumber, postalCode}});
  }
}
