import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserModel } from '../Models/user.model';
import { AuthService } from '../Services/auth.service';
import { CreateOrderService } from '../Services/create-order.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  user : UserModel;
  price : number = 0;
  constructor(private auth : AuthService, private orderService: CreateOrderService) {


   }

  ngOnInit(): void {
    if (this.user === undefined)
    {
    this.user = this.auth.user
    }
    this.user.shoppingCart.products.forEach(product => {
      this.price += product.price;
    });

  }

  submitOrder(form : NgForm){
    const typeOfShipment = form.value.flexRadioDefault;
    this.orderService.postOrder(typeOfShipment).subscribe(res => {
      console.log(res);
    })

  }


}
