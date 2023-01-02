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
  errorMessage = new Subject<string>();
  user : UserModel;
  message :string = '';
  constructor(private loginService: AuthService, private router:Router) { }

  ngOnInit(): void {
    this.errorMessage.subscribe(res => {
        this.message = res;
    })
  }

  onSubmit(form: NgForm){
    const credentials = form.value;
    this.loginService.logIn(credentials.nickName, credentials.password).subscribe(response => {
      if (response)
      {
        localStorage.setItem('token',response);
        this.router.navigate(['']);
        this.loginService.getUserByNickName(credentials.nickName).subscribe(res => {
          this.user = res;
          this.loginService.userSubject.next(this.user);
          this.loginService.isLoged.next(true);
          localStorage.setItem("user", JSON.stringify(this.user));
        });
      }

    }, error => {
      this.errorMessage.next(error.error);
    });

      }

      register(){
      this.router.navigate(["./register"]);
      }


}
