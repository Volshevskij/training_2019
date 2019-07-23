import { Component, OnInit } from '@angular/core';
import {FirstService} from './first.service';

@Component({
  selector: 'app-main-form-component',
  templateUrl: './main-form-component.component.html',
  styleUrls: ['./main-form-component.component.css'],
  providers: [FirstService]
})
export class MainFormComponentComponent implements OnInit {

  ngOnInit() {
  }

   constructor(private service: FirstService) {
  }

}
