import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CreateOrderService {

  constructor(private http: HttpClient) { }

  postOrder(typeOfShipment : number){
    return this.http.post("https://localhost:63150/api/Order", {Shipment : typeOfShipment});
  }
}
