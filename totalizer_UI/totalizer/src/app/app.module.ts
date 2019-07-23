import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainFormComponentComponent } from './main-form-component/main-form-component.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FirstService } from './main-form-component/first.service';
import { BetsComponent } from './bets/bets.component';
import { CountriesComponent } from './countries/countries.component';
import { CountriesService } from './countries/countries.sevice';
import { AdditionalInfoComponent } from './additional-info/additional-info.component';
import { NavbarComComponent } from './navbar-com/navbar-com.component';
import { EventsComponent } from './events/events.component';
import { SideNavigationComponent } from './side-navigation/side-navigation.component';
import { PersonsComponent } from './persons/persons.component';
import { InternalSearchComponent } from './internal-search/internal-search.component';
import { TeamsComponent } from './teams/teams.component';
import { SportTypesComponent } from './sport-types/sport-types.component';
import { DbInfoComponent } from './db-info/db-info.component';
import { SportTypesService } from './sport-types/sport-types.service';
import { TeamsService } from './teams/teams.service';
import { BetBoxComponent } from './bet-box/bet-box.component';
import { EventBoxComponent } from './event-box/event-box.component';
import { RolesComponent } from './roles/roles.component';
import { RegistrationComponent } from './registration/registration.component';
import { AuthorizationComponent } from './authorization/authorization.component';
import { UsersComponent } from './users/users.component';
import { MyBetsComponent } from './my-bets/my-bets.component';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { MyBetsBoxComponent } from './my-bets-box/my-bets-box.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { AuthGuard } from './auth.guard';
import { AuthInterceptor } from './auth.interceptor';
import { routes } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    MainFormComponentComponent,
    BetsComponent,
    CountriesComponent,
    AdditionalInfoComponent,
    NavbarComComponent,
    EventsComponent,
    SideNavigationComponent,
    PersonsComponent,
    InternalSearchComponent,
    TeamsComponent,
    SportTypesComponent,
    DbInfoComponent,
    BetBoxComponent,
    EventBoxComponent,
    RolesComponent,
    RegistrationComponent,
    AuthorizationComponent,
    UsersComponent,
    MyBetsComponent,
    MyProfileComponent,
    MyBetsBoxComponent,
    ForbiddenComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
     RouterModule.forRoot(routes)
      //  [
    //   { path: 'app-main-form-component', component: MainFormComponentComponent }
    // ])
  ],
  providers: [CountriesService, FirstService, SportTypesService, TeamsService, AuthGuard,
  {
    provide : HTTP_INTERCEPTORS,
    useClass : AuthInterceptor,
    multi : true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
