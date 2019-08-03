import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from '../users/users.service';
import { UserInfoService } from '../_Shared/userInfo.service';
import {subject} from '../_Shared/userInfo.service';

@Component({
  selector: 'app-navbar-com',
  templateUrl: './navbar-com.component.html',
  styleUrls: ['./navbar-com.component.css'],
  providers: [UsersService, UserInfoService]
})
export class NavbarComComponent implements OnInit {

  constructor(private router: Router, public userService: UsersService, private userInfo: UserInfoService) { }
  sc: any;
  user = 'Guest';
  ngOnInit() {
   this.setName();
   subject.subscribe((data: string) => this.user = data);
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
