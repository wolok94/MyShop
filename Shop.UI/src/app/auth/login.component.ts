import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { UserModel } from '../Models/user.model';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  responseData : any;

  user : UserModel;
  constructor(private loginService: AuthService, private router:Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    const credentials = form.value;
    this.loginService.logIn(credentials.nickName, credentials.password);
    if(this.loginService.logIn)
    {
    this.loginService.getUserByNickName(credentials.nickName)
      .subscribe(res => {
        this.user = res;
        this.loginService.userSubject.next(this.user);
      });
    }
      }

      register(){
      this.router.navigate(["./register"]);
      }

}
