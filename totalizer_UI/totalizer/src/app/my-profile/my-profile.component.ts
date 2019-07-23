import { Component, OnInit } from '@angular/core';
import { Person } from '../persons/Models/Person';
import { PersonsService } from '../persons/persons.service';
import { HttpClient } from '@angular/common/http';
import { UsersService } from '../users/users.service';
import { Account } from '../users/Models/Account';
import { User } from '../users/Models/User';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css'],
  providers: [PersonsService, UsersService]
})
export class MyProfileComponent implements OnInit {

  public person: Person;
  sc: Person;
  login: string;
  user: Account;
  st: Account;
  sm: User;
  constructor(private service: PersonsService, http: HttpClient, private usersService: UsersService) {
  }

  async ngOnInit() {
    this.person = new Person();
    this.person.Id = 0;
    this.person.FirstName = '';
    this.person.MiddleName = '';
    this.person.LastName = '';
    this.person.Phone = '';
    this.user = new Account();
    this.user.Person = new Person();
    this.user.Person.Id = 0;

    this.closeUpdateBox();
    this.closeGreyground();
    this.closePasBox();
    await this.getUser();
  }

 async getUser() {
   this.login = localStorage.getItem('userName');
   await this.usersService.getMatchingUser(this.login).subscribe((data: Person) => this.person = data);
  }

  setValues() {
    const elementFirstName = (document.getElementById('updateInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('updateInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('updateInputLastName')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('updateInputPhone')) as HTMLSelectElement;

    elementFirstName.value = this.person.FirstName;
    elementMiddleName.value = this.person.MiddleName;
    elementLastName.value = this.person.LastName;
    elementPhone.value = this.person.Phone;
  }

 async getPerson(id: number) {
    await this.service.getPersonById(id).subscribe((data: Person) => (this.person = data));

    const elementFirstName = (document.getElementById('updateInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('updateInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('updateInputLastName')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('updateInputPhone')) as HTMLSelectElement;

    elementFirstName.value = this.person.FirstName;
    elementMiddleName.value = this.person.MiddleName;
    elementLastName.value = this.person.LastName;
    elementPhone.value = this.person.Phone;
  }

  updatePerson() {
    const elementFirstName = (document.getElementById('updateInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('updateInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('updateInputLastName')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('updateInputPhone')) as HTMLSelectElement;

    this.person.FirstName = elementFirstName.value;
    this.person.MiddleName = elementMiddleName.value;
    this.person.LastName = elementLastName.value;
    this.person.Phone = elementPhone.value;

    this.service.updatePerson(this.person).subscribe((data: Person) => this.sc = data);
  }

  openGreyground() {
    document.getElementById('greyground').style.display = 'block';
  }

   closeGreyground() {
    document.getElementById('greyground').style.display = 'none';
  }

  openUpdateBox() {
    document.getElementById('updatebox').style.display = 'block';
  }

   closeUpdateBox() {
    document.getElementById('updatebox').style.display = 'none';
  }

  openPasBox() {
    document.getElementById('passwordbox').style.display = 'block';
    }

    closePasBox() {
    document.getElementById('passwordbox').style.display = 'none';
    }

    changePassword() {
      const elementOldPas = (document.getElementById('pasInputOld')) as HTMLSelectElement;
      const elementNewPas = (document.getElementById('pasInputNew')) as HTMLSelectElement;
      const elementConfPas = (document.getElementById('pasInputConf')) as HTMLSelectElement;
      const user = new User();
      user.Password = elementOldPas.value;
      user.NewPassword = elementNewPas.value;
      user.ConfirmPassword = elementConfPas.value;

      this.usersService.changePassword(user).subscribe((data: User) => this.sm = data);
    }

}
