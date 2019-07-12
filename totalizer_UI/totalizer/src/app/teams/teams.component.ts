import { Component, OnInit } from '@angular/core';
import { Team } from './Models/Team';
import {TeamsService} from './teams.service';
import { HttpClient } from '@angular/common/http';
import { Country } from '../countries/Models/Country';


@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css'],
  providers: [TeamsService]
})
export class TeamsComponent implements OnInit {

  constructor(private service: TeamsService, http: HttpClient) {
  }

  public teams: Team[];
  public countries: Country[];
  sc: Team;
  public currentTeam: string;
  public currentCountry: string;
  tempId: number;
  countryTempId: number;

  ngOnInit() {
    this.closeGreyground();
    this.closeAddBox();
    this.closeUpdateBox();
    this.closeDeleteBox();
    this.getTeams();
    this.getContries();
    this.countryTempId = 0;
    this.countries[this.countryTempId] = new Country();
    this.tempId = 0;
    this.teams[this.tempId] = new Team();
    this.teams[this.tempId].Country = this.countries[this.countryTempId];
  }

  getContries() {
    this.countries = [];
    this.service.getCountries().subscribe((data: Country[]) => (this.countries = data, console.log(typeof this.countries)));
  }

  getCurrentCountry(elementId: string) {
    const element = (document.getElementById(elementId)) as HTMLSelectElement;
    const select = element.selectedIndex;
    const option = element.options[select];
    this.currentCountry = option.value;
    this.countryTempId = parseInt(this.currentCountry);
    console.log('lk');
    console.log(this.currentCountry);
  }

  getTeams() {
    this.teams = [];
    this.service.getTeams().subscribe((data: Team[]) => (this.teams = data, console.log(typeof this.teams)));
  }

  getCurrentTeam() {
    const element = (document.getElementById('teams-list')) as HTMLSelectElement;
    const select = element.selectedIndex;
    const option = element.options[select];
    this.currentTeam = option.value;
    this.tempId = parseInt(this.currentTeam);
    console.log(this.tempId);
  }

  updateTeam() {
    const element = (document.getElementById('updateInputT')) as HTMLSelectElement;
    this.getCurrentCountry('inteams-contry-list-update');
    const newTeam = new Team();
    newTeam.Name = element.value;
    console.log('LOH');
    console.log(element.value);
    newTeam.Country = this.countries[this.countryTempId];
    newTeam.Id = this.teams[this.tempId].Id;
    this.teams[this.tempId] = newTeam;
    element.value = '';
    this.service.updateTeam(newTeam).subscribe((data: Team) => this.sc = data);
    // this.getCountries();
  }

  addTeam() {
    const element = (document.getElementById('addInputT')) as HTMLSelectElement;
    this.getCurrentCountry('inteams-contry-list-add');
    const newTeam = new Team();
    newTeam.Name = element.value;
    newTeam.Country = this.countries[this.countryTempId];
    element.value = '';
    this.service.addTeam(newTeam).subscribe((data: Team) => this.sc = data);
  }

  deleteTeam() {
    this.service.deleteTeam(this.teams[this.tempId].Id).subscribe((data: Team) => this.sc = data);
  }

  refreshPage() {
    window.location.reload();
  }

  openGreyground() {
    document.getElementById('greygroundT').style.display = 'block';
  }

   closeGreyground() {
    document.getElementById('greygroundT').style.display = 'none';
  }

  openAddBox() {
    document.getElementById('addboxT').style.display = 'block';
  }

   closeAddBox() {
    document.getElementById('addboxT').style.display = 'none';
  }

  openUpdateBox() {
    document.getElementById('updateboxT').style.display = 'block';
  }

   closeUpdateBox() {
    document.getElementById('updateboxT').style.display = 'none';
  }

  openDeleteBox() {
    document.getElementById('deleteboxT').style.display = 'block';
  }

   closeDeleteBox() {
    document.getElementById('deleteboxT').style.display = 'none';
  }
}
