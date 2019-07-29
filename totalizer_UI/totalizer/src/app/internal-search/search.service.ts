import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bet } from '../bets/Models/Bet';
import { Event } from '../events/Models/Event';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};

@Injectable()

export class SearchService {
  constructor(private http: HttpClient) {
  }

  searchBet(bets: Bet[], searchId: number, searchString: string) {
    const result: Bet[] = [];

    if (searchId === 1) {
      const date = searchString + 'T00:00:00';
      for(let i = 0; i < bets.length; i++) {
        if (bets[i].Date.toString() === date) {
            result.push(bets[i]);
        }
      }
    }

    if (searchId === 2) {
      const sportId = parseInt(searchString);
      for(let i = 0; i < bets.length; i++) {
        if (bets[i].Event.SportType.Id === sportId) {
            result.push(bets[i]);
        }
      }
    }

    if (searchId === 3) {
      const status = searchString;
      for(let i = 0; i < bets.length; i++) {
        if (bets[i].Event.Status === status) {
            result.push(bets[i]);
        }
      }
    }
    return result;
  }

  searchEvent(events: Event[], searchId: number, searchString: string) {
    const result: Event[] = [];

    if (searchId === 1) {
      const date = searchString + 'T00:00:00';
      for(let i = 0; i < events.length; i++) {
        if (events[i].Date.toString() === date) {
            result.push(events[i]);
        }
      }
    }

    if (searchId === 2) {
      const sportId = parseInt(searchString);
      for(let i = 0; i < events.length; i++) {
        if (events[i].SportType.Id === sportId) {
            result.push(events[i]);
        }
      }
    }

    if (searchId === 3) {
      const status = searchString;
      for (let i = 0; i < events.length; i++) {
        if (events[i].Status === status) {
            result.push(events[i]);
        }
      }
    }

    return result;
  }
}
