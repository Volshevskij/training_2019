import { Component, OnInit } from '@angular/core';
import { RegisterInfo } from './Models/RegisterInfo';
import { RegistrationService } from './registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [RegistrationService]
})
export class RegistrationComponent implements OnInit {

  constructor(private regService: RegistrationService) { }

  regModel: RegisterInfo;

  ngOnInit() {
  }

  register() {
    const elementLogin = (document.getElementById('login')) as HTMLSelectElement;
    const elementEmail = (document.getElementById('email')) as HTMLSelectElement;
    const elementPassord = (document.getElementById('password')) as HTMLSelectElement;
    const elementConfPassword = (document.getElementById('confirmPassword')) as HTMLSelectElement;

    this.regModel = new RegisterInfo();

    this.regModel.Login = elementLogin.value;
    this.regModel.Email = elementEmail.value;
    this.regModel.Password = elementPassord.value;
    this.regModel.ConfirmPassword = elementConfPassword.value;

    this.regService.register(this.regModel);
  }

}
