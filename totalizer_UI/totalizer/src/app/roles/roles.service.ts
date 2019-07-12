import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Role } from './Models/Role';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class RolesService {
  constructor(private http: HttpClient) {
  }

  getRoles() {
   return this.http.get('http://localhost:25128/api/role');
 }

  updateRole(role: Role) {
   return this.http.patch('http://localhost:25128/api/role', role);
 }

  addRole(role: Role) {
  return this.http.post('http://localhost:25128/api/role', role);
 }

  deleteRole(id: number) {
  return this.http.delete('http://localhost:25128/api/role/' + id);
 }
}
