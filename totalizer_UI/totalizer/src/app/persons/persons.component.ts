import { Component, OnInit } from '@angular/core';
import {PersonsService} from './persons.service';
import { Person } from './Models/Person';
import { HttpClient } from '@angular/common/http';
import { UsersService } from '../users/users.service';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
  providers: [PersonsService]
})
export class PersonsComponent implements OnInit {

  constructor(private service: PersonsService, http: HttpClient, public userService: UsersService) {
  }

  public persons: Person[];
  sc: Person;
  public currentPerson: string;
  tempId: number;

  ngOnInit() {
    this.closeAddBox();
    this.closeDeleteBox();
    this.closeUpdateBox();
    this.closeGreyground();
    this.getPersons();

    this.tempId = 0;
    this.persons[0] = new Person();
    this.persons[0].LastName = '';
  }

  getPersons() {
    this.persons = [];
    this.service.getPersons().subscribe((data: Person[]) => (this.persons = data));
  }

  getCurrentPerson(id: string) {
    const element = (document.getElementById('updateButton' + id)) as HTMLSelectElement;
    this.tempId = parseInt(element.value);

    const elementFirstName = (document.getElementById('updateInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('updateInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('updateInputLastName')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('updateInputPhone')) as HTMLSelectElement;

    elementFirstName.value = this.persons[this.tempId].FirstName;
    elementMiddleName.value = this.persons[this.tempId].MiddleName;
    elementLastName.value = this.persons[this.tempId].LastName;
    elementPhone.value = this.persons[this.tempId].Phone;
  }

  updatePerson() {
    const elementFirstName = (document.getElementById('updateInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('updateInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('updateInputLastName')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('updateInputPhone')) as HTMLSelectElement;

    this.persons[this.tempId].FirstName = elementFirstName.value;
    this.persons[this.tempId].MiddleName = elementMiddleName.value;
    this.persons[this.tempId].LastName = elementLastName.value;
    this.persons[this.tempId].Phone = elementPhone.value;

    this.service.updatePerson(this.persons[this.tempId]).subscribe((data: Person) => this.sc = data);
  }

  addPerson() {
    const elementFirstName = (document.getElementById('addInputFirstName')) as HTMLSelectElement;
    const elementMiddleName = (document.getElementById('addInputMiddleName')) as HTMLSelectElement;
    const elementLastName = (document.getElementById('addInputLastName')) as HTMLSelectElement;
    const elementPhone = (document.getElementById('addInputPhone')) as HTMLSelectElement;

    const newPerson = new Person();
    newPerson.FirstName = elementFirstName.value;
    newPerson.MiddleName = elementMiddleName.value;
    newPerson.LastName = elementLastName.value;
    newPerson.Phone = elementPhone.value;
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
