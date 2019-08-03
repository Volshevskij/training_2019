import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';

export const subject = new Subject<string>();


const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class UserInfoService {
  constructor(private http: HttpClient) {
  }

  nextData( data: string) {
   subject.next(data);
  }

  getData() {
    return subject;
  }

}
