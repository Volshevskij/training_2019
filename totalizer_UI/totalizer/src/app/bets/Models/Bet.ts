import { Person } from 'src/app/persons/Models/Person';
import {Event} from 'src/app/events/Models/Event';
import { Team } from 'src/app/teams/Models/Team';

export class Bet {
  Id: number;
  Person: Person;
  Event: Event;
  Coefficient: number;
  Date: Date;
  Amount: number;
  Team: Team;
}
