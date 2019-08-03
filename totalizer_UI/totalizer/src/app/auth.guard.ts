import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { UsersService } from './users/users.service';


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private userService: UsersService) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
      if (localStorage.getItem('userToken') != null) {
        // tslint:disable-next-line: no-string-literal
        const roles = next.data['roles'] as Array<string>;
        if (roles) {
          const match = this.userService.roleMatch(roles);
          if (match) { return true; } else {
            this.router.navigate(['/app-forbidden']);
            return false;
          }
        } else {
          return true;
        }
      }
      this.router.navigate(['/app-authorization']);
      return false;
  }
}
