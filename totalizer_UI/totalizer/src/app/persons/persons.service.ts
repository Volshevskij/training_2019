import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Person } from './Models/Person';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class PersonsService {
  constructor(private http: HttpClient) {
  }

  getPersons() {
   return this.http.get('http://localhost:25128/api/person');
 }

  updatePerson(person: Person) {
   return this.http.patch('http://localhost:25128/api/person', person);
 }

  addPerson(person: Person) {
  return this.http.post('http://localhost:25128/api/person', person);
 }

  deletePerson(id: number) {
  return this.http.delete('http://localhost:25128/api/person/' + id);
 }
}
