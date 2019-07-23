import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RegisterInfo } from './Models/RegisterInfo';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class RegistrationService {
  constructor(private http: HttpClient) {
  }

  register(obj: RegisterInfo) {
  this.http.post('http://localhost:25128/api/Account/Register', obj);
 }

}
