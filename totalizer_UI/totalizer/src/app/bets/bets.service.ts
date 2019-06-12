import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*'
  })
};

@Injectable()

export class FirstService {
  constructor(private http: HttpClient) {

  }

  getInfo() {
    return this.http.get('http://localhost:25128/Home/GetAllPersons');
 }
}
