import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { User } from './Models/User';
import { Account } from './Models/Account';
import { Person } from '../persons/Models/Person';
import { UpdateModel } from './Models/UpdateModel';


const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};

@Injectable()

export class UsersService {
  readonly rootUrl = 'http://localhost:8989';
  constructor(private http: HttpClient) {
  }

  registerUser(user: User) {
    user.Roles = [];
    user.Roles.push('User');

    return this.http.post('http://localhost:8989/api/Account/Register', user);
  }

  test() {
    return this.http.get('http://localhost:8989/api/Account/Test');
  }

  userAuthentication(userName, password) {
    const data = 'username=' + userName + '&password=' + password + '&grant_type=password';
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded' });
    return this.http.post(this.rootUrl + '/Token', data, { headers: reqHeader });
  }

  getUserClaims() {
   return  this.http.get(this.rootUrl + '/api/GetUserClaims');
  }

  getAllRoles() {
    const reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    return this.http.get(this.rootUrl + '/api/role', { headers: reqHeader });
  }

  roleMatch(allowedRoles): boolean {

    if (allowedRoles === null || localStorage.getItem('userRoles') === null) {
      return false;
    }

    let isMatch = false;
    const userRoles: string[] = JSON.parse(localStorage.getItem('userRoles'));
    allowedRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }

  getMatchingUser(login: string) {
   return this.http.get(this.rootUrl + '/api/user/' + login);
  }

  createUserModel(login: string) {
    const acc = new Account();
    acc.Login = login;
    acc.Person = new Person();
    return this.http.post(this.rootUrl + '/api/user/', acc);
  }

  getMatchingBets(login: string) {
    return this.http.get(this.rootUrl + '/api/matching_bet/' + login);
  }

  changePassword(user: User) {
    return this.http.post(this.rootUrl + '/api/Account/ChangePassword/', user);
  }

  changeUserPassword(user: User) {
    return this.http.post(this.rootUrl + '/api/Account/ChangeUserPassword/', user);
  }

  updateUser(model: UpdateModel) {
    return this.http.post(this.rootUrl + '/api/Account/UpdateUserAcc/', model);
  }

  deleteUser(user: User) {
    return this.http.post(this.rootUrl + '/api/Account/DeleteUserAcc/', user);
  }

  getUsers() {
    return this.http.get(this.rootUrl + '/api/Account/accounts/');
  }

  logout() {
    return this.http.post(this.rootUrl + '/api/Account/Logout', []);
  }
}
