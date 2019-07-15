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

const routes: Routes = [
  {path: 'app-main-form-component', component: MainFormComponentComponent},
  {path: 'app-countries', component : CountriesComponent},
  {path: 'app-navbar-com', component: NavbarComComponent},
  {path: 'app-events', component: EventsComponent},
  {path: 'app-side-navigation', component : SideNavigationComponent},
  {path: 'app-bets', component : BetsComponent},
  {path: 'app-internal-search', component : InternalSearchComponent},
  {path: 'app-sport-types', component: SportTypesComponent},
  {path: 'app-teams', component: TeamsComponent},
  {path: 'app-db-info', component: DbInfoComponent},
  {path: 'app-bet-box', component: BetBoxComponent},
  {path: 'app-event-box', component: EventBoxComponent},
  {path: 'app-persons', component: PersonsComponent},
  {path: 'app-registration', component: RegistrationComponent},
  {path: 'app-authorization', component: AuthorizationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
