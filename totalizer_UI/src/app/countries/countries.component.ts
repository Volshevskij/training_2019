import { Component, OnInit } from '@angular/core';
import {CountriesService} from './countries.sevice';
import { Country } from './Models/Country';
@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css']
})
export class CountriesComponent implements OnInit {

  countries: Country[];
  constructor(private service: CountriesService) {

  }

  ngOnInit() {
    this.getCountries();
  }

  getCountries() {
    this.service.getInfo().subscribe((data: Country[]) => this.countries = data);
  }
}
