import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Event } from './Models/Event';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization' : 'authkey',
    'userid' : '1'
  })
};


@Injectable()

export class EventsService {
  constructor(private http: HttpClient) {
  }

  getEvents() {
   return this.http.get('http://localhost:8989/api/event');
 }

  updateEvent(event: Event) {
   return this.http.patch('http://localhost:8989/api/event', event);
 }

  addEvent(event: Event) {
  return this.http.post('http://localhost:8989/api/event', event);
 }

  deleteEvent(id: number) {
  return this.http.delete('http://localhost:8989/api/event/' + id);
 }
}
