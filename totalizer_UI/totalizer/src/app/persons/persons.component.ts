import { Component, OnInit } from '@angular/core';
import {PersonsService} from './persons.service';
import { Person } from './Models/Person';
import { HttpClient } from '@angular/common/http';
import { RolesService } from '../roles/roles.service';
import { Role } from '../roles/Models/Role';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
  providers: [PersonsService, RolesService]
})
export class PersonsComponent implements OnInit {

  constructor(private service: PersonsService, http: HttpClient, private rolesService: RolesService ) {
  }

  public persons: Person[];
  sc: Person;
  public currentPerson: string;
  tempId: number;

  public roles: Role[];
  roleTempId: number;

  ngOnInit() {
    this.closeAddBox();
    this.closeDeleteBox();
    this.closeUpdateBox();
    this.closeGreyground();

    this.getPersons();
    this.getRoles();

    this.tempId = 0;
    this.persons[0] = new Person();
    this.persons[0].LastName = '';
  }

  getPersons() {
    this.persons = [];
    this.service.getPersons().subscribe((data: Person[]) => (this.persons = data, console.log(typeof this.persons)));
  }

  getRoles() {
    this.roles = [];
    this.rolesService.getRoles().subscribe((data: Role[]) => (this.roles = data));
  }

  getCurrentPerson(id: string) {
    const element = (document.getElementById('updateButton' + id)) as HTMLSelectElement;
    this.tempId = parseInt(element.value);
  }

  updatePerson() {
    const elementFirstName = (document.getElementById('updateInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('updateInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('updateInputLastName')) as HTMLSelectElement;
    const elementEmail = (document.getElementById('updateInputEmail')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('updateInputPhone')) as HTMLSelectElement;
    const elementRole = (document.getElementById('updateInputRole')) as HTMLSelectElement;
    const elementPassword = (document.getElementById('updateInputLogin')) as HTMLSelectElement;
    const elementLogin = (document.getElementById('updateInputPassword')) as HTMLSelectElement;

    this.persons[this.tempId].FirstName = elementFirstName.value;
    this.persons[this.tempId].MiddleName = elementMiddleName.value;
    this.persons[this.tempId].LastName = elementLastName.value;
    this.persons[this.tempId].Email = elementEmail.value;
    this.persons[this.tempId].Phone = elementPhone.value;
    this.persons[this.tempId].Role = this.roles[parseInt(elementRole.value)];
    this.persons[this.tempId].Password = elementPassword.value;
    this.persons[this.tempId].Login = elementLogin.value;

    this.service.updatePerson(this.persons[this.tempId]).subscribe((data: Person) => this.sc = data);
  }

  addPerson() {
    const elementFirstName = (document.getElementById('addInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('addInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('addInputLastName')) as HTMLSelectElement;
    const elementEmail = (document.getElementById('addInputEmail')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('addInputPhone')) as HTMLSelectElement;
    const elementRole = (document.getElementById('addInputRole')) as HTMLSelectElement;
    const elementPassword = (document.getElementById('addInputLogin')) as HTMLSelectElement;
    const elementLogin = (document.getElementById('addInputPassword')) as HTMLSelectElement;
    const newPerson = new Person();
    newPerson.FirstName = elementFirstName.value;
    newPerson.MiddleName = elementMiddleName.value;
    newPerson.LastName = elementLastName.value;
    newPerson.Email = elementEmail.value;
    newPerson.Phone = elementPhone.value;
    newPerson.Role = this.roles[parseInt(elementRole.value)];
    newPerson.Password = elementPassword.value;
    newPerson.Login = elementLogin.value;
    this.service.addPerson(newPerson).subscribe((data: Person) => this.sc = data);
  }

  deletePerson() {
    this.service.deletePerson(this.persons[this.tempId].Id).subscribe((data: Person) => this.sc = data);
  }

  refreshPage() {
    window.location.reload();
  }

  openGreyground() {
    document.getElementById('greyground').style.display = 'block';
  }

   closeGreyground() {
    document.getElementById('greyground').style.display = 'none';
  }

  openAddBox() {
    document.getElementById('addbox').style.display = 'block';
  }

   closeAddBox() {
    document.getElementById('addbox').style.display = 'none';
  }

  openUpdateBox() {
    document.getElementById('updatebox').style.display = 'block';
  }

   closeUpdateBox() {
    document.getElementById('updatebox').style.display = 'none';
  }

  openDeleteBox() {
    document.getElementById('deletebox').style.display = 'block';
  }

   closeDeleteBox() {
    document.getElementById('deletebox').style.display = 'none';
  }
}
