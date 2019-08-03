import { Component, OnInit, ViewChild, AfterViewInit, Injectable, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../persons/Models/Person';
import { Event } from '../events/Models/Event';
import { EventsService } from '../events/events.service';
import { PersonsService } from '../persons/persons.service';
import { Team } from '../teams/Models/Team';
import { TeamsService } from '../teams/teams.service';
import { SearchService } from '../internal-search/search.service';
import { InternalSearchComponent } from '../internal-search/internal-search.component';
import { BetsService } from '../bets/bets.service';
import { Bet } from '../bets/Models/Bet';
import { UsersService } from '../users/users.service';
import { User } from '../users/Models/User';

@Component({
  selector: 'app-my-bets',
  templateUrl: './my-bets.component.html',
  styleUrls: ['./my-bets.component.css'],
  providers: [BetsService, EventsService, PersonsService, SearchService, InternalSearchComponent, UsersService]
})
export class MyBetsComponent implements OnInit {

  @Input() search: InternalSearchComponent;

  constructor(private service: BetsService, private eventService: EventsService, private personsService: PersonsService,
              private teamsService: TeamsService, http: HttpClient, private searchService: SearchService,
              private usersService: UsersService) {
  }

  public  booleanData = {};

  sc: Bet;

  login: string;
  user: User;

  public bets: Bet[];
  betTempId: number;
  betsReserve: Bet[];

  events: Event[];
  eventTempId: number;

  person: Person;

  teams: Team[];
  teamTempId: number;

 async ngOnInit() {

  this.closeAddBox();
  this.closeDeleteBox();
  this.closeUpdateBox();
  this.closeGreyground();

  this.betTempId = 0;
  this.eventTempId = 0;

  this.teams = [];
  this.teams[0] = new Team();
  this.teams[0].Id = 0;
  this.teams[0].Name = '';

  this.events = [];
  this.events[0] = new Event();
  this.events[0].Team1 = this.teams[0];
  this.events[0].Team2 = this.teams[0];
  this.events[0].Status = '';

  this.person = new Person();
  this.person.FirstName = '';
  this.person.MiddleName = '';
  this.person.LastName = '';
  this.person.Phone = '';

  this.bets = [];
  this.bets[0] = new Bet();
  this.bets[0].Id = 0;
  this.bets[0].Event = this.events[0];
  this.bets[0].Team = this.teams[0];
  this.bets[0].Amount = 1;
  this.bets[0].Coefficient = 1;
  this.bets[0].Date = new Date('0001-01-01');
  this.bets[0].Person = this.person;

  this.getEvents();
  this.getTeams();
  this.getUser();
  await this.getMatchingBets();
  }

  getEvents() {
    this.events = [];
    this.eventService.getEvents().subscribe((data: Event[]) => this.events = data);
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

  getCurrentTeam(holderId: string) {
    const element = (document.getElementById(holderId)) as HTMLSelectElement;
    this.teamTempId = parseInt(element.value);
  }

  updateBet() {
    this.getCurrentEvent('updateInputEvent');
    const elementDate = (document.getElementById('updateInputDate')) as HTMLSelectElement;
    const elementCoefficient = (document.getElementById('updateInputCoefficient')) as HTMLSelectElement;
    const elementAmount = (document.getElementById('updateInputAmount')) as HTMLSelectElement;
    const elementTeam = (document.getElementById('updateInputTeam')) as HTMLSelectElement;
    const teamOption = parseInt(elementTeam.value);
    this.bets[this.betTempId].Date = new Date(elementDate.value);
    this.bets[this.betTempId].Coefficient = parseInt(elementCoefficient.value);
    this.bets[this.betTempId].Amount = parseFloat(elementAmount.value);
    this.bets[this.betTempId].Event = this.events[this.eventTempId];
    this.bets[this.betTempId].Person = this.person;
    if (teamOption === 0) {
      this.bets[this.betTempId].Team = this.bets[this.betTempId].Event.Team1;
    } else {
      this.bets[this.betTempId].Team = this.bets[this.betTempId].Event.Team2;
    }
    this.service.updateBet(this.bets[this.betTempId]).subscribe((data: Bet) => this.sc = data);
  }

  addBet() {
    this.getCurrentEvent('addInputEvent');
    this.getCurrentTeam('addInputTeam');
    const elementDate = (document.getElementById('addInputDate')) as HTMLSelectElement;
    const elementCoefficient = (document.getElementById('addInputCoefficient')) as HTMLSelectElement;
    const elementAmount = (document.getElementById('addInputAmount')) as HTMLSelectElement;
    const newBet = new Bet();
    newBet.Date = new Date(elementDate.value);
    newBet.Coefficient = parseInt(elementCoefficient.value);
    newBet.Amount = parseFloat(elementAmount.value);
    newBet.Event = this.events[this.eventTempId];
    newBet.Person = this.person;
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
    console.log(this.person.Id);
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

   async getUser() {
   this.login = localStorage.getItem('userName');
   await this.usersService.getMatchingUser(this.login).subscribe((data: Person) => this.person = data);
   }

   async getMathcingBet(id: number) {
   await this.service.getMatchingBet(this.user.Person.Id).subscribe((data: Bet[]) => this.bets = data);
  }

  async getMatchingBets() {
   this.login = localStorage.getItem('userName');
   await this.usersService.getMatchingBets(this.login).subscribe((data: Bet[]) => this.bets = data);
  }

}
