import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Country } from './Models/Country';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class CountriesService {
  constructor(private http: HttpClient) {
  }

  getCountries() {
   return this.http.get('http://localhost:25128/api/country');
 }

  updateCountry(country: Country) {
   return this.http.patch('http://localhost:25128/api/country', country);
 }

  addCountry(country: Country) {
  return this.http.post('http://localhost:25128/api/country', country);
 }

  deleteCountry(id: number) {
  return this.http.delete('http://localhost:25128/api/country/' + id);
 }
}
