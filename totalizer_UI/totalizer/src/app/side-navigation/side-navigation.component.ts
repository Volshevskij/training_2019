import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users/users.service';

@Component({
  selector: 'app-side-navigation',
  templateUrl: './side-navigation.component.html',
  styleUrls: ['./side-navigation.component.css'],
  providers: [UsersService]
})
export class SideNavigationComponent implements OnInit {

  constructor(public userService: UsersService) { }

  ngOnInit() {
  }

  openNav() {
    document.getElementById('mySidenav').style.width = '250px';
  }
   closeNav() {
    document.getElementById('mySidenav').style.width = '0';
  }
}
