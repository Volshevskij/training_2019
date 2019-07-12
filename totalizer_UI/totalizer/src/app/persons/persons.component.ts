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
  }

  getPersons() {
    this.persons = [];
    this.service.getPersons().subscribe((data: Person[]) => (this.persons = data, console.log(typeof this.persons)));
  }

  getRoles() {
    this.roles = [];
    this.rolesService.getRoles().subscribe((data: Role[]) => (this.roles = data));
  }

  getCurrentPerson() {
    const element = (document.getElementById('countries-list')) as HTMLSelectElement;
    const select = element.selectedIndex;
    const option = element.options[select];
    this.currentPerson = option.value;
    this.tempId = parseInt(this.currentPerson);
    console.log(this.tempId);
  }

  updatePerson() {
    const element = (document.getElementById('updateInput')) as HTMLSelectElement;
    //this.persons[this.tempId].Name = element.value;
    element.value = '';
    this.service.updatePerson(this.persons[this.tempId]).subscribe((data: Person) => this.sc = data);
  }

  addPerson() {
    const element = (document.getElementById('addInput')) as HTMLSelectElement;
    const newCountry = new Person();
   //newCountry.Name = element.value;
    element.value = '';
    this.service.addPerson(newCountry).subscribe((data: Person) => this.sc = data);
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
