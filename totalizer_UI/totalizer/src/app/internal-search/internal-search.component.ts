import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-internal-search',
  templateUrl: './internal-search.component.html',
  styleUrls: ['./internal-search.component.css']
})

export class InternalSearchComponent implements OnInit {
  constructor() {
   }
   showed = false;
  ngOnInit() {
    this.showed = false;
    this.closeBox();
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
}
