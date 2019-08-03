import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule, FormControl } from '@angular/forms';
import { UsersService } from '../users/users.service';
import { BrowserModule } from '@angular/platform-browser';
import { AuthorizeModel } from './Models/AuthorizeModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { AppComponent } from '../app.component';
import { UserInfoService } from '../_Shared/userInfo.service';
import {subject} from '../_Shared/userInfo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css'],
  providers: [UsersService, UserInfoService]
})

@NgModule({
  imports: [
      BrowserModule,
      FormsModule,
      ReactiveFormsModule
  ],
  declarations: [
      AppComponent
  ],
  bootstrap: [AppComponent]
})

export class AuthorizationComponent implements OnInit {

  constructor(private authService: UsersService, private http: HttpClient, private formBuilder: FormBuilder,
              private userInfo: UserInfoService, private router: Router) {
  }

  authModel: AuthorizeModel;
  sc: any;

  authForm: FormGroup;
  submitted = false;

  ngOnInit() {
    subject.subscribe({
      next: (data) => localStorage.getItem('userName')
    });
    this.authForm = new FormGroup({
      login: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
    this.createForm();
  }

  async authorize() {
    const elementLogin = (document.getElementById('login')) as HTMLSelectElement;
    const elementPassord = (document.getElementById('password')) as HTMLSelectElement;

    this.authModel = new AuthorizeModel();

    this.authModel.Login = elementLogin.value;
    this.authModel.Password = elementPassord.value;


    this.authService.userAuthentication(this.authModel.Login, this.authModel.Password).subscribe((data: any) => {
      localStorage.setItem('userToken', data.access_token);
      localStorage.setItem('userRoles', data.role);
      localStorage.setItem('userName', data.userName);
      subject.next(localStorage.getItem('userName'));
      this.navigate();
    });
  }

  createForm() {
    this.authForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
  });
}

get f() { return this.authForm.controls; }

onSubmit() {
    this.submitted = true;
    if (this.authForm.invalid) {
      return;
  } else {
    this.authorize();
  }
}

navigate() {
  this.router.navigate(['/app-bets']);
}

}
