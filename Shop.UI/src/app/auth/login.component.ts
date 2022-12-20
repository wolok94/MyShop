import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  responseData : any;
  constructor(private loginService: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    const credentials = form.value;
    this.loginService.logIn(credentials.nickName, credentials.password)
  }

}
