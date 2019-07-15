import { Component, OnInit, Input } from '@angular/core';
import {EventsService} from './events.service';
import { Event } from './Models/Event';
import { HttpClient } from '@angular/common/http';
import { SportTypesService } from '../sport-types/sport-types.service';
import { Team } from '../teams/Models/Team';
import { SportType } from '../sport-types/Models/SportType';
import { TeamsService } from '../teams/teams.service';
import { InternalSearchComponent } from '../internal-search/internal-search.component';
import { SearchService } from '../internal-search/search.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css'],
  providers: [EventsService, SportTypesService, TeamsService, SearchService]
})
export class EventsComponent implements OnInit {

  @Input() search: InternalSearchComponent;

  constructor(private service: EventsService, http: HttpClient, private sportTypeService: SportTypesService,
              private teamService: TeamsService, private searchService: SearchService) {
  }

  sc: Event;

  public events: Event[];
  eventTempId: number;
  eventsReserve: Event[];

  public teams: Team[];
  team1TempId: number;
  team2TempId: number;

  public sportTypes: SportType[];
  sportTypeTempId: number;

  ngOnInit() {
    this.closeAddBox();
    this.closeDeleteBox();
    this.closeUpdateBox();
    this.closeGreyground();
    this.getEvents();
    this.getTeams();
    this.getSportTypes();
    this.team1TempId = 0;
    this.team2TempId = 0;
    this.teams[this.team1TempId] = new Team();
    this.teams[this.team2TempId] = new Team();
    this.sportTypeTempId = 0;
    this.sportTypes[this.sportTypeTempId] = new SportType();
    this.eventTempId = 0;
    this.events[this.eventTempId] = new Event();
    this.events[this.eventTempId].SportType = this.sportTypes[this.sportTypeTempId];
    this.events[this.eventTempId].Team1 = this.teams[this.team1TempId];
    this.events[this.eventTempId].Team2 = this.teams[this.team2TempId];
  }

  getEvents() {
    this.events = [];
    this.eventsReserve = [];
    this.service.getEvents().subscribe((data: Event[]) => (this.events = data));
    this.service.getEvents().subscribe((data: Event[]) => (this.eventsReserve = data));
  }

  getTeams() {
    this.teams = [];
    this.teamService.getTeams().subscribe((data: Team[]) => (this.teams = data, console.log(typeof this.teams)));
  }

  getSportTypes() {
    this.sportTypes = [];
    this.sportTypeService.getSportTypes().subscribe((data: SportType[]) => (this.sportTypes = data, console.log(typeof this.sportTypes)));
  }

  getCurrentEvent(Id: string) {
    const element = (document.getElementById('updateButton' + Id)) as HTMLSelectElement;
    this.eventTempId = parseInt(element.value);
    console.log(this.eventTempId);
  }

  getCurrentTeams(holderId1: string, holderId2: string) {
    const elementTeam1 = (document.getElementById(holderId1)) as HTMLSelectElement;
    const elementTeam2 = (document.getElementById(holderId2)) as HTMLSelectElement;
    this.team1TempId = parseInt(elementTeam1.value);
    this.team2TempId = parseInt(elementTeam2.value);
  }

  getCurrentSportType(holderId: string) {
    const elementSportType = (document.getElementById(holderId)) as HTMLSelectElement;
    this.sportTypeTempId = parseInt(elementSportType.value);
  }

  updateEvent() {
    this.getCurrentTeams('updateInputTeam1', 'updateInputTeam2');
    this.getCurrentSportType('updateInputSportType');
    const elementDate = (document.getElementById('updateInputDate')) as HTMLSelectElement;
    const elementStatus = (document.getElementById('updateInputStatus')) as HTMLSelectElement;
    this.events[this.eventTempId].Date = new Date(elementDate.value);
    console.log(this.events[this.eventTempId].Date);
    this.events[this.eventTempId].Team1 = this.teams[this.team1TempId];
    this.events[this.eventTempId].Team2 = this.teams[this.team2TempId];
    this.events[this.eventTempId].SportType = this.sportTypes[this.sportTypeTempId];
    this.events[this.eventTempId].Status = elementStatus.value;
    this.service.updateEvent(this.events[this.eventTempId]).subscribe((data: Event) => this.sc = data);
  }

  addEvent() {
    this.getCurrentTeams('addInputTeam1', 'addInputTeam2');
    this.getCurrentSportType('addInputSportType');
    const elementDate = (document.getElementById('addInputDate')) as HTMLSelectElement;
    const elementStatus = (document.getElementById('addInputStatus')) as HTMLSelectElement;
    const newEvent = new Event();
    newEvent.Date = new Date(elementDate.value);
    newEvent.Team1 = this.teams[this.team1TempId];
    newEvent.Team2 = this.teams[this.team2TempId];
    newEvent.SportType = this.sportTypes[this.sportTypeTempId];
    newEvent.Status = elementStatus.value;
    this.service.addEvent(newEvent).subscribe((data: Event) => this.sc = data);
  }

  deleteEvent() {
    console.log(this.events[this.eventTempId].Id);
    this.service.deleteEvent(this.events[this.eventTempId].Id).subscribe((data: Event) => this.sc = data);
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
    const tmp = this.searchService.searchEvent(this.eventsReserve, this.search.searchId, this.search.searchString);

    if (tmp[0] != null) {
      this.events = tmp;
    } else {
      this.refreshPage();
    }

  }
}
