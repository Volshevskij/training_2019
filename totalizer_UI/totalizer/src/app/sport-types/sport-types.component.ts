import { Component, OnInit } from '@angular/core';
import { SportType } from './Models/SportType';
import {SportTypesService} from './sport-types.service';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-sport-types',
  templateUrl: './sport-types.component.html',
  styleUrls: ['./sport-types.component.css'],
  providers: [SportTypesService]
})
export class SportTypesComponent implements OnInit {

  constructor(private service: SportTypesService, http: HttpClient) {
  }

  public sportTypes: SportType[];
  sc: SportType;
  public currentSportType: string;
  tempId: number;

  ngOnInit() {
    this.closeGreyground();
    this.closeAddBox();
    this.closeUpdateBox();
    this.closeDeleteBox();
    this.getSportTypes();
    this.tempId = 0;
    this.sportTypes[this.tempId] = new SportType();
  }

  getSportTypes() {
    this.sportTypes = [];
    this.service.getSportTypes().subscribe((data: SportType[]) => (this.sportTypes = data));
  }

  getCurrentSportType() {
    const element = (document.getElementById('sportTypes-list')) as HTMLSelectElement;
    const select = element.selectedIndex;
    const option = element.options[select];
    this.currentSportType = option.value;
    this.tempId = parseInt(this.currentSportType);

    const elementUpdate = (document.getElementById('updateInputS')) as HTMLSelectElement;
    elementUpdate.value = this.sportTypes[this.tempId].Name;
  }

  updateSportType() {
    const element = (document.getElementById('updateInputS')) as HTMLSelectElement;
    this.sportTypes[this.tempId].Name = element.value;
    element.value = '';
    this.service.updateSportType(this.sportTypes[this.tempId]).subscribe((data: SportType) => this.sc = data);
  }

  addSportType() {
    const element = (document.getElementById('addInputS')) as HTMLSelectElement;
    const newCountry = new SportType();
    newCountry.Name = element.value;
    element.value = '';
    this.service.addSportType(newCountry).subscribe((data: SportType) => this.sc = data);
  }

  deleteSportType() {
    this.service.deleteSportType(this.sportTypes[this.tempId].Id).subscribe((data: SportType) => this.sc = data);
  }

  refreshPage() {
    window.location.reload();
  }

  openGreyground() {
    document.getElementById('greygroundS').style.display = 'block';
  }

   closeGreyground() {
    document.getElementById('greygroundS').style.display = 'none';
  }

  openAddBox() {
    document.getElementById('addboxS').style.display = 'block';
  }

   closeAddBox() {
    document.getElementById('addboxS').style.display = 'none';
  }

  openUpdateBox() {
    document.getElementById('updateboxS').style.display = 'block';
  }

   closeUpdateBox() {
    document.getElementById('updateboxS').style.display = 'none';
  }

  openDeleteBox() {
    document.getElementById('deleteboxS').style.display = 'block';
  }

   closeDeleteBox() {
    document.getElementById('deleteboxS').style.display = 'none';
  }
}
