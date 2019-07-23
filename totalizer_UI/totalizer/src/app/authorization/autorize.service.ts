import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthorizeModel } from './Models/AuthorizeModel';


const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class AuthorizeService {
  constructor(private http: HttpClient) {
  }

  register(obj: AuthorizeModel) {
  this.http.post('http://localhost:25128/api/Account/Login', obj);
 }

}
