import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule, FormControl } from '@angular/forms';
import { UsersService } from '../users/users.service';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from '../app.component';
import { User } from '../users/Models/User';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css'],
    providers: [UsersService]
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

 export class RegistrationComponent implements OnInit {
    registerForm: FormGroup;
    submitted = false;

    constructor(private formBuilder: FormBuilder, public regService: UsersService) { }

    regModel: User;
    roles: string[];
    sc: any;

    proove: User[];

    inUse = false;

    ngOnInit() {
      this.registerForm = new FormGroup({
        login: new FormControl('', Validators.required),
        email: new FormControl('', Validators.required),
        password: new FormControl('', Validators.required),
        confirmPassword: new FormControl('', Validators.required)
      });
      this.createForm();
      this.getUsers();
    }

    get f() { return this.registerForm.controls; }

    onSubmit() {
        this.submitted = true;
        if (this.registerForm.invalid || this.inUse) {
          return;
      } else {
        this.register();
      }
    }

 MustMatch(controlName: string, matchingControlName: string) {
      return (formGroup: FormGroup) => {
          const control = formGroup.controls[controlName];
          const matchingControl = formGroup.controls[matchingControlName];

          if (matchingControl.errors && !matchingControl.errors.mustMatch) {
              return;
          }

          if (control.value !== matchingControl.value) {
              matchingControl.setErrors({ mustMatch: true });
          } else {
              matchingControl.setErrors(null);
          }
      };
    }

    async register() {
    const elementLogin = (document.getElementById('login')) as HTMLSelectElement;
    const elementEmail = (document.getElementById('email')) as HTMLSelectElement;
    const elementPassord = (document.getElementById('password')) as HTMLSelectElement;
    const elementConfPassword = (document.getElementById('confirmPassword')) as HTMLSelectElement;

    let isMatch = false;
    this.proove.forEach(element => {
      if (element.Login === elementLogin.value) {
        isMatch = true;
        return false;
      }
    });

    if (isMatch) {
        alert('Login already in use');
        return;
    } else {
      this.regModel = new User();
      this.roles = [];
      this.regModel.Login = elementLogin.value;
      this.regModel.Email = elementEmail.value;
      this.regModel.Password = elementPassord.value;
      this.regModel.ConfirmPassword = elementConfPassword.value;
      alert('Success');
      this.regService.registerUser(this.regModel).subscribe((data: any) => this.sc = data);
    }
  }

  getUsers() {
    this.regService.getUsers().subscribe((data: User[]) => this.proove = data);
  }

    createForm() {
      this.registerForm = this.formBuilder.group({
        login: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', Validators.required]
    }, {
        validator: this.MustMatch('password', 'confirmPassword')
    });
  }
}
