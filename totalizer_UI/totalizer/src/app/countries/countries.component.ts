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

  greygroundShowed = false;
  addBoxShowed = false;
  updateBoxShowed = false;
  deleteBoxShowed = false;

  ngOnInit() {
    this.getCountries();
    this.greygroundShowed = false;
    this.addBoxShowed = false;
    this.updateBoxShowed = false;
    this.deleteBoxShowed = false;
    this.closeGreyground();
    this.closeAddBox();
    this.closeUpdateBox();
    this.closeDeleteBox();
  }

  toggleGreyground() {
    if (this.greygroundShowed === false) {
      this.greygroundShowed = true;
      this.openGreyground();
    } else {
      this.greygroundShowed = false;
      this.closeGreyground();
    }
  }

  openGreyground() {
    document.getElementById('greyground').style.display = 'block';
  }

   closeGreyground() {
    document.getElementById('greyground').style.display = 'none';
  }

  toggleAddBox() {
    if (this.addBoxShowed === false) {
      this.addBoxShowed = true;
      this.openAddBox();
    } else {
      this.addBoxShowed = false;
      this.closeAddBox();
    }
  }

  openAddBox() {
    document.getElementById('addbox').style.display = 'block';
  }

   closeAddBox() {
    document.getElementById('addbox').style.display = 'none';
  }

  toggleUpdateBox() {
    if (this.updateBoxShowed === false) {
      this.updateBoxShowed = true;
      this.openUpdateBox();
    } else {
      this.updateBoxShowed = false;
      this.closeUpdateBox();
    }
  }

  openUpdateBox() {
    document.getElementById('updatebox').style.display = 'block';
  }

   closeUpdateBox() {
    document.getElementById('updatebox').style.display = 'none';
  }

  toggleDeleteBox() {
    if (this.deleteBoxShowed === false) {
      this.deleteBoxShowed = true;
      this.openDeleteBox();
    } else {
      this.deleteBoxShowed = false;
      this.closeDeleteBox();
    }
  }

  openDeleteBox() {
    document.getElementById('deletebox').style.display = 'block';
  }

   closeDeleteBox() {
    document.getElementById('deletebox').style.display = 'none';
  }
  getCountries() {
    this.service.getCountries().subscribe((data: Country[]) => this.countries = data);
  }

}
