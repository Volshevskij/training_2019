import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar-com',
  templateUrl: './navbar-com.component.html',
  styleUrls: ['./navbar-com.component.css']
})
export class NavbarComComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }
  bringWindowUp() {
    window.scrollTo(0, 0);
  }

  Logout() {
    localStorage.removeItem('userToken');
    this.router.navigate(['/app-authorization']);
  }
}
