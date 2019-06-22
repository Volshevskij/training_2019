import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {FirstService} from './first.service';

@Component({
  selector: 'app-main-form-component',
  templateUrl: './main-form-component.component.html',
  styleUrls: ['./main-form-component.component.css'],
  providers: [FirstService]
})
export class MainFormComponentComponent implements OnInit {

  public rgli: number;

  ngOnInit() {

   this.firstMethod();
  }

   constructor(private service: FirstService) {

  }

 firstMethod() {
   this.service.getInfo().subscribe((data: number) => this.rgli = data);
 }
}
