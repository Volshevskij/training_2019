import { Component, OnInit, Injectable } from '@angular/core';
import {CountriesService} from './countries.sevice';
import { Country } from './Models/Country';
import { HttpClient } from '@angular/common/http';

@Injectable()

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css'],
  providers: [CountriesService]
})
export class CountriesComponent implements OnInit {


  constructor(private service: CountriesService, http: HttpClient) {
  }

  public countries: Country[];
  sc: Country;
  public currentCountry: string;
  tempId: number;

  ngOnInit() {
    this.closeGreyground();
    this.closeAddBox();
    this.closeUpdateBox();
    this.closeDeleteBox();
    this.getCountries();
    this.tempId = 0;
    this.countries[this.tempId] = new Country();
  }

  getCountries() {
    this.countries = [];
    this.service.getCountries().subscribe((data: Country[]) => (this.countries = data, console.log(typeof this.countries)));
  }

  getCurrentCountry() {
    const element = (document.getElementById('countries-list')) as HTMLSelectElement;
    const select = element.selectedIndex;
    const option = element.options[select];
    this.currentCountry = option.value;
    this.tempId = parseInt(this.currentCountry);
    console.log(this.tempId);
  }

  updateCountry() {
    const element = (document.getElementById('updateInput')) as HTMLSelectElement;
    this.countries[this.tempId].Name = element.value;
    element.value = '';
    this.service.updateCountry(this.countries[this.tempId]).subscribe((data: Country) => this.sc = data);
    // this.getCountries();
  }

  addCountry() {
    const element = (document.getElementById('addInput')) as HTMLSelectElement;
    const newCountry = new Country();
    newCountry.Name = element.value;
    element.value = '';
    this.service.addCountry(newCountry).subscribe((data: Country) => this.sc = data);
  }

  deleteCountry() {
    this.service.deleteCountry(this.countries[this.tempId].Id).subscribe((data: Country) => this.sc = data);
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
}
