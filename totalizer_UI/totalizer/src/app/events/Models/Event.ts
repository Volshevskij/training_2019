import { Team } from 'src/app/teams/Models/Team';
import { SportType } from 'src/app/sport-types/Models/SportType';

export class Event {
  Id: number;
  Date: Date;
  Team1: Team;
  Team2: Team;
  SportType: SportType;
  Status: string;
}
