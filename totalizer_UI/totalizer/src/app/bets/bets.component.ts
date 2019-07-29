import { Component, OnInit, ViewChild, AfterViewInit, Injectable, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Bet } from './Models/Bet';
import {BetsService} from './bets.service';
import { Person } from '../persons/Models/Person';
import { Event } from '../events/Models/Event';
import { EventsService } from '../events/events.service';
import { PersonsService } from '../persons/persons.service';
import { Team } from '../teams/Models/Team';
import { TeamsService } from '../teams/teams.service';
import { SearchService } from '../internal-search/search.service';
import { InternalSearchComponent } from '../internal-search/internal-search.component';
import { UsersService } from '../users/users.service';

@Injectable()

@Component({
  selector: 'app-bets',
  templateUrl: './bets.component.html',
  styleUrls: ['./bets.component.css'],
  providers: [BetsService, EventsService, PersonsService, SearchService, InternalSearchComponent]
})

export class BetsComponent implements OnInit {

  @Input() search: InternalSearchComponent;

  constructor(private service: BetsService, private eventService: EventsService, private personsService: PersonsService,
              private teamsService: TeamsService, private searchService: SearchService, public userService: UsersService) {
  }

  public  booleanData = {};

  sc: Bet;

  public bets: Bet[];
  betTempId: number;
  betsReserve: Bet[];

  events: Event[];
  eventTempId: number;

  persons: Person[];
  personTempId: number;

  teams: Team[];
  teamTempId: number;

  ngOnInit() {
    this.closeAddBox();
    this.closeDeleteBox();
    this.closeUpdateBox();
    this.closeGreyground();

    this.getBets();
    this.getEvents();
    this.getPersons();
    this.getTeams();

    this.betTempId = 0;
    this.eventTempId = 0;
    this.personTempId = 0;

    this.persons[this.personTempId] = new Person();
    this.events[this.eventTempId] = new Event();
    this.bets[this.betTempId] = new Bet();
    this.events[this.eventTempId].Team1 = new Team();
    this.events[this.eventTempId].Team2 = new Team();
    this.bets[this.betTempId].Event = this.events[this.eventTempId];
    this.bets[this.betTempId].Person = this.persons[this.personTempId];
    this.bets[this.betTempId].Id = 0;
    this.bets[this.betTempId].Team = new Team();
  }

  getBets() {
    this.bets = [];
    this.betsReserve = [];
    this.service.getBets().subscribe((data: Bet[]) => this.bets = data);
    this.service.getBets().subscribe((data: Bet[]) => this.betsReserve = data);
  }

  getEvents() {
    this.events = [];
    this.eventService.getEvents().subscribe((data: Event[]) => this.events = data);
  }

  getPersons() {
    this.persons = [];
    this.personsService.getPersons().subscribe((data: Person[]) => this.persons = data);
  }

  getTeams() {
    this.teams = [];
    this.teamsService.getTeams().subscribe((data: Team[]) => this.teams = data);
  }

  getCurrentBet(id: string) {
    const element = (document.getElementById('updateButton' + id)) as HTMLSelectElement;
    this.betTempId = parseInt(element.value);
  }

  getCurrentEvent(holderId: string) {
    const element = (document.getElementById(holderId)) as HTMLSelectElement;
    this.eventTempId = parseInt(element.value);
  }

  getCurrentPerson(holderId: string) {
    const element = (document.getElementById(holderId)) as HTMLSelectElement;
    this.personTempId = parseInt(element.value);
  }

  getCurrentTeam(holderId: string) {
    const element = (document.getElementById(holderId)) as HTMLSelectElement;
    this.teamTempId = parseInt(element.value);
  }

  updateBet() {
    this.getCurrentEvent('updateInputEvent');
    this.getCurrentPerson('updateInputPerson');
    this.getCurrentTeam('updateInputTeam');
    const elementDate = (document.getElementById('updateInputDate')) as HTMLSelectElement;
    const elementCoefficient = (document.getElementById('updateInputCoefficient')) as HTMLSelectElement;
    const elementAmount = (document.getElementById('updateInputAmount')) as HTMLSelectElement;

    this.bets[this.betTempId].Date = new Date(elementDate.value);
    this.bets[this.betTempId].Coefficient = parseInt(elementCoefficient.value);
    this.bets[this.betTempId].Amount = parseFloat(elementAmount.value);
    this.bets[this.betTempId].Event = this.events[this.eventTempId];
    this.bets[this.betTempId].Person = this.persons[this.personTempId];
    this.bets[this.betTempId].Team = this.teams[this.teamTempId];

    this.service.updateBet(this.bets[this.betTempId]).subscribe((data: Bet) => this.sc = data);
  }

  addBet() {
    this.getCurrentEvent('addInputEvent');
    this.getCurrentPerson('addInputPerson');
    this.getCurrentTeam('addInputTeam');
    const elementDate = (document.getElementById('addInputDate')) as HTMLSelectElement;
    const elementCoefficient = (document.getElementById('addInputCoefficient')) as HTMLSelectElement;
    const elementAmount = (document.getElementById('addInputAmount')) as HTMLSelectElement;

    const newBet = new Bet();
    newBet.Date = new Date(elementDate.value);
    newBet.Coefficient = parseInt(elementCoefficient.value);
    newBet.Amount = parseFloat(elementAmount.value);
    newBet.Event = this.events[this.eventTempId];
    newBet.Person = this.persons[this.personTempId];
    newBet.Team = this.teams[this.teamTempId];

    this.service.addBet(newBet).subscribe((data: Bet) => this.sc = data);
  }

  deleteBet() {
    this.service.deleteBet(this.bets[this.betTempId].Id).subscribe((data: Bet) => this.sc = data);
  }

  refreshPage() {
    window.location.reload();
  }

  openGreyground() {
    document.getElementById('greyground').style.display = 'block';
  }

   closeGreyground() {
    document.getElementById('greyground').style.display = 'none';
  }

  openAddBox() {
    document.getElementById('addbox').style.display = 'block';
  }

   closeAddBox() {
    document.getElementById('addbox').style.display = 'none';
  }

  openUpdateBox() {
    document.getElementById('updatebox').style.display = 'block';
  }

   closeUpdateBox() {
    document.getElementById('updatebox').style.display = 'none';
  }

  openDeleteBox() {
    document.getElementById('deletebox').style.display = 'block';
  }

   closeDeleteBox() {
    document.getElementById('deletebox').style.display = 'none';
  }

  searchInfo() {
    this.search.getSearchInfo();
    const tmp = this.searchService.searchBet(this.betsReserve, this.search.searchId, this.search.searchString);

    if (tmp[0] != null) {
      this.bets = tmp;
    } else {
      this.refreshPage();
    }

  }
}
