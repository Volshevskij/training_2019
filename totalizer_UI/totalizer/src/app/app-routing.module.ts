import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MainFormComponentComponent} from './main-form-component/main-form-component.component';
import {CountriesComponent} from './countries/countries.component';
import {NavbarComComponent} from './navbar-com/navbar-com.component';
import {EventsComponent} from './events/events.component';
import {SideNavigationComponent} from './side-navigation/side-navigation.component';
import {BetsComponent} from './bets/bets.component';
import {InternalSearchComponent} from './internal-search/internal-search.component';
import {SportTypesComponent} from './sport-types/sport-types.component';
import {TeamsComponent} from './teams/teams.component';
import {DbInfoComponent} from './db-info/db-info.component';
import { BetBoxComponent } from './bet-box/bet-box.component';
import { EventBoxComponent } from './event-box/event-box.component';
import { PersonsComponent } from './persons/persons.component';
import { RegistrationComponent } from './registration/registration.component';
import { AuthorizationComponent } from './authorization/authorization.component';
import { UsersComponent } from './users/users.component';
import { MyBetsBoxComponent } from './my-bets-box/my-bets-box.component';
import { MyBetsComponent } from './my-bets/my-bets.component';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { AuthGuard } from './auth.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';


export const routes: Routes = [
  {path: 'app-main-form-component', component: MainFormComponentComponent},
  {path: 'app-countries', component : CountriesComponent, canActivate: [AuthGuard], data: { roles: ['Editor'] }},
  {path: 'app-navbar-com', component: NavbarComComponent},
  {path: 'app-events', component: EventsComponent},
  {path: 'app-side-navigation', component : SideNavigationComponent, canActivate: [AuthGuard], data: { roles: ['Editor'] }},
  {path: 'app-bets', component : BetsComponent},
  {path: 'app-internal-search', component : InternalSearchComponent},
  {path: 'app-sport-types', component: SportTypesComponent, canActivate: [AuthGuard], data: { roles: ['Editor'] }},
  {path: 'app-teams', component: TeamsComponent, canActivate: [AuthGuard], data: { roles: ['Editor'] }},
  {path: 'app-db-info', component: DbInfoComponent, canActivate: [AuthGuard], data: { roles: ['Editor', 'User'] }},
  {path: 'app-bet-box', component: BetBoxComponent},
  {path: 'app-event-box', component: EventBoxComponent},
  {path: 'app-persons', component: PersonsComponent},
  {path: 'app-registration', component: RegistrationComponent},
  {path: 'app-authorization', component: AuthorizationComponent},
  {path: 'app-users', component: UsersComponent},
  {path: 'app-my-bets-box', component: MyBetsBoxComponent}, // canActivate: [AuthGuard], data: { roles: ['User'] }},
  {path: 'app-my-bets', component: MyBetsComponent}, // canActivate: [AuthGuard], data: { roles: ['User'] }},
  {path: 'app-my-profile', component: MyProfileComponent}, // canActivate: [AuthGuard], data: { roles: ['User'] }},
  {path: 'app-forbidden', component: ForbiddenComponent},
  { path : '', redirectTo: '/app-main-form-component', pathMatch : 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
