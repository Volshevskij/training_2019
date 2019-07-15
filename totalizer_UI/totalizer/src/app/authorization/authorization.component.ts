import { Component, OnInit } from '@angular/core';
import { AuthorizeModel } from './Models/AuthorizeModel';
import { AuthorizeService } from './autorize.service';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css'],
  providers: [AuthorizeService]
})
export class AuthorizationComponent implements OnInit {

  constructor(private authService: AuthorizeService) { }

  authModel: AuthorizeModel;

  ngOnInit() {
  }

  authorize() {
    const elementLogin = (document.getElementById('login')) as HTMLSelectElement;
    const elementPassord = (document.getElementById('password')) as HTMLSelectElement;

    this.authModel = new AuthorizeModel();

    this.authModel.Login = elementLogin.value;
    this.authModel.Password = elementPassord.value;

    this.authService.register(this.authModel);
  }

}
