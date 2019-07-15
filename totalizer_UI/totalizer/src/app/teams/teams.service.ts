import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Team } from './Models/Team';
const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class TeamsService {
  constructor(private http: HttpClient) {

  }

  getCountries() {
    return this.http.get('http://localhost:25128/api/country');
  }

  getTeams() {
    return this.http.get('http://localhost:25128/api/team');
  }

   updateTeam(team: Team) {
    return this.http.patch('http://localhost:25128/api/team', team);
  }

   addTeam(team: Team) {
   return this.http.post('http://localhost:25128/api/team', team);
  }

   deleteTeam(id: number) {
   return this.http.delete('http://localhost:25128/api/team/' + id);
  }
}
