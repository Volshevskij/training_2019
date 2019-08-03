import { Component, OnInit, NgModule, Injectable, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SportTypesService } from '../sport-types/sport-types.service';
import { SportType } from '../sport-types/Models/SportType';
import { SearchService } from './search.service';

@Injectable()

@Component({
  selector: 'app-internal-search',
  templateUrl: './internal-search.component.html',
  styleUrls: ['./internal-search.component.css'],
  providers: [SportTypesService, SearchService]
})

export class InternalSearchComponent implements OnInit {
   public constructor(http: HttpClient, private sportTypeService: SportTypesService, private searchServie: SearchService) {
   }

   dateCheck = true;
   sportCheck = false;
   statusCheck = false;
   showed = false;
   sportTypes: SportType[];
   searchString = '';
   searchId = 0;

  ngOnInit() {
    this.closeBox();
    this.getSportTypes();
    this.disableSportTypeSearch();
    this.disableStatusSearch();
  }

  getSportTypes() {
    this.sportTypes = [];
    this.sportTypeService.getSportTypes().subscribe((data: SportType[]) => this.sportTypes = data);
  }

  toggleForm() {
    if (this.showed === false) {
      this.showed = true;
      this.openBox();
    } else {
      this.showed = false;
      this.closeBox();
    }
  }

  openBox() {
    document.getElementById('options').style.display = 'block';
  }

   closeBox() {
    document.getElementById('options').style.display = 'none';
  }

  enableDateSearch() {
    this.dateCheck = true;
    document.getElementById('search-holder-date').style.display = 'block';
  }

  enableSportTypeSearch() {
    this.sportCheck = true;
    document.getElementById('search-holder-sportTypes').style.display = 'block';
  }

  enableStatusSearch() {
    this.statusCheck = true;
    document.getElementById('search-holder-status').style.display = 'block';
  }

  disableDateSearch() {
    this.dateCheck = false;
    document.getElementById('search-holder-date').style.display = 'none';
  }

  disableSportTypeSearch() {
    this.sportCheck = false;
    document.getElementById('search-holder-sportTypes').style.display = 'none';
  }

  disableStatusSearch() {
    this.statusCheck = false;
    document.getElementById('search-holder-status').style.display = 'none';
  }

  getSearchInfo() {
    console.log('Inf');
    if (this.dateCheck === true) {
      this.searchId = 1;
      const element = (document.getElementById('search-holder-date')) as HTMLSelectElement;
      this.searchString = element.value;
      console.log('Date');
    }

    if (this.sportCheck === true) {
      this.searchId = 2;
      const element = (document.getElementById('search-holder-sportTypes')) as HTMLSelectElement;
      this.searchString = element.value;
      console.log('Sport');
    }

    if (this.statusCheck === true) {
      this.searchId = 3;
      const element = (document.getElementById('search-holder-status')) as HTMLSelectElement;
      this.searchString = element.value;
      console.log('State');
    }
  }
}
