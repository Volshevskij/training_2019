import { Person } from 'src/app/persons/Models/Person';

export class User {
  Id: string;
  Login: string;
  Email: string;
  Password: string;
  NewPassword: string;
  ConfirmPassword: string;
  Roles: string[];
  Person: Person;
}
