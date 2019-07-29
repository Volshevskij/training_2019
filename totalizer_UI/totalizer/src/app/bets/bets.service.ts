import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Bet} from './Models/Bet';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};

@Injectable()

export class BetsService {
  constructor(private http: HttpClient) {
  }

  getBets() {
   return this.http.get('http://localhost:8989/api/bet');
 }

  updateBet(bet: Bet) {
   return this.http.patch('http://localhost:8989/api/bet', bet);
 }

  addBet(bet: Bet) {
  return this.http.post('http://localhost:8989/api/bet', bet);
 }

  deleteBet(id: number) {
  return this.http.delete('http://localhost:8989/api/bet/' + id);
 }

  getMatchingBet(id: number) {
  return this.http.get('http://localhost:8989/api/match_bet/' + id);
 }
}
