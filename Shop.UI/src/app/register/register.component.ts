import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddressModel } from '../Models/address.model';
import { RegisterService } from '../Services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private registerService: RegisterService) { }

  ngOnInit(): void {
  }

  onRegister(form: NgForm){
    const credentials = form.value;
    this.registerService.registerUser(credentials.FirstName, credentials.LastName,
      credentials.Email, credentials.UserName, credentials.Password, credentials.Country, credentials.City, credentials.Street,
      credentials.HouseNumber, credentials.PostalCode).subscribe(res => {
      console.log(res);
    });
  }

}
