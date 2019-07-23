import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users/users.service';
import { User } from '../users/Models/User';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';
import * as rsx from 'rxjs';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [UsersService]
})
export class RegistrationComponent implements OnInit {

  constructor(public regService: UsersService, http: HttpClient) { }

  regModel: User;
  roles: string[];
  sc: any;

  ngOnInit() {
  }

 async register() {
    const elementLogin = (document.getElementById('login')) as HTMLSelectElement;
    const elementEmail = (document.getElementById('email')) as HTMLSelectElement;
    const elementPassord = (document.getElementById('password')) as HTMLSelectElement;
    const elementConfPassword = (document.getElementById('confirmPassword')) as HTMLSelectElement;

    this.regModel = new User();
    this.roles = [];
    this.regModel.Login = elementLogin.value;
    this.regModel.Email = elementEmail.value;
    this.regModel.Password = elementPassord.value;
    this.regModel.ConfirmPassword = elementConfPassword.value;

    this.regService.registerUser(this.regModel, this.roles).subscribe((data: any) => this.sc = data);
    this.regService.userAuthentication(this.regModel.Login, this.regModel.Password).subscribe((data: any) => {
      localStorage.setItem('userToken', data.access_token);
      localStorage.setItem('userRoles', data.role);
      localStorage.setItem('userName', data.username);
    });
  }
}
