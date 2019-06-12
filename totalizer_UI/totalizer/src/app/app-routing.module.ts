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

const routes: Routes = [
  {path: 'app-main-form-component', component: MainFormComponentComponent},
  {path: 'app-countries', component : CountriesComponent},
  {path: 'app-navbar-com', component: NavbarComComponent},
  {path: 'app-events', component: EventsComponent},
  {path: 'app-side-navigation', component : SideNavigationComponent},
  {path: 'app-bets', component : BetsComponent},
  {path: 'app-internal-search', component : InternalSearchComponent},
  {path: 'app-sport-types', component: SportTypesComponent},
  {path: 'app-teams', component: TeamsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
