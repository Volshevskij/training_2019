import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SportType } from './Models/SportType';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class SportTypesService {
  constructor(private http: HttpClient) {

  }

  getSportTypes() {
    return this.http.get('http://localhost:25128/api/sport_type');
  }

   updateSportType(sportType: SportType) {
    return this.http.patch('http://localhost:25128/api/sport_type', sportType);
  }

   addSportType(sportType: SportType) {
   return this.http.post('http://localhost:25128/api/sport_type', sportType);
  }

   deleteSportType(id: number) {
   return this.http.delete('http://localhost:25128/api/sport_type/' + id);
  }
}
