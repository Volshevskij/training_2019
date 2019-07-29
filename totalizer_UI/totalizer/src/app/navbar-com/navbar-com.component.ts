import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from '../users/users.service';

@Component({
  selector: 'app-navbar-com',
  templateUrl: './navbar-com.component.html',
  styleUrls: ['./navbar-com.component.css'],
  providers: [UsersService]
})
export class NavbarComComponent implements OnInit {

  constructor(private router: Router, public userService: UsersService) { }
  sc: any;
  user = 'Guest';
  ngOnInit() {
    this.setName();
  }

  bringWindowUp() {
    window.scrollTo(0, 0);
  }

 async setName() {
    this.user = await localStorage.getItem('userName');
  }

  Logout() {
    this.user = 'Guest';
    localStorage.removeItem('userToken');
    localStorage.removeItem('userRoles');
    localStorage.removeItem('userName');
    this.router.navigate(['/app-authorization']);
  }

  refreshPage() {
    window.location.reload();
  }
}
