import { Component, OnInit } from '@angular/core';
import { AuthorizeModel } from './Models/AuthorizeModel';
import { UsersService } from '../users/users.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css'],
  providers: [UsersService]
})
export class AuthorizationComponent implements OnInit {

  constructor(private authService: UsersService, private http: HttpClient) {
  }

  authModel: AuthorizeModel;
  sc: any;
  ngOnInit() {
  }

   authorize() {
    const elementLogin = (document.getElementById('login')) as HTMLSelectElement;
    const elementPassord = (document.getElementById('password')) as HTMLSelectElement;

    this.authModel = new AuthorizeModel();

    this.authModel.Login = elementLogin.value;
    this.authModel.Password = elementPassord.value;

    this.authService.userAuthentication(this.authModel.Login, this.authModel.Password).subscribe((data: any) => {
      localStorage.setItem('userToken', data.access_token);
      localStorage.setItem('userRoles', data.role);
      localStorage.setItem('userName', data.userName);
    });
  }
}
