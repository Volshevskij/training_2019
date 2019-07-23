import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { HttpClient } from '@angular/common/http';
import { User } from './Models/User';
import { RolesService } from '../roles/roles.service';
import { Role } from '../roles/Models/Role';
import { UpdateModel } from './Models/UpdateModel';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UsersService, RolesService]
})
export class UsersComponent implements OnInit {

  constructor(private service: UsersService, http: HttpClient, private rolesService: RolesService) {
}

sc: User;

roles: Role[];

public users: User[];
usersTempId: number;
oldUser: User;


ngOnInit() {
this.closeAddBox();
this.closeDeleteBox();
this.closeUpdateBox();
this.closeGreyground();
this.closePasBox();

this.usersTempId = 0;
this.users = [];
this.users[0] = new User();

this.getRoles();
this.getUsers();
}

getCurrentUser(Id: string) {
const element = (document.getElementById('updateButton' + Id)) as HTMLSelectElement;
this.usersTempId = parseInt(element.value);
this.oldUser = this.users[this.usersTempId];
// const elementLogin = (document.getElementById('updateInputLogin')) as HTMLSelectElement;
const elementEmail = (document.getElementById('updateInputEmail')) as HTMLSelectElement;

// elementLogin.value = this.users[this.usersTempId].Login;
elementEmail.value = this.users[this.usersTempId].Email;
}

getRoles() {
 this.rolesService.getRoles().subscribe((data: Role[]) => this.roles = data);
}

addUser() {
  const elementLogin = (document.getElementById('addInputLogin')) as HTMLSelectElement;
  const elementEmail = (document.getElementById('addInputEmail')) as HTMLSelectElement;
  const elementPas = (document.getElementById('addInputPassword')) as HTMLSelectElement;
  const elementConfPas = (document.getElementById('addInputConfirmPassword')) as HTMLSelectElement;
  const elementRole = (document.getElementById('addInputRole')) as HTMLSelectElement;
  const newUser = new User();
  newUser.Login = elementLogin.value;
  newUser.Email = elementEmail.value;
  newUser.Password = elementPas.value;
  newUser.ConfirmPassword = elementConfPas.value;

  const newRoles: string[] = [];

  if(parseInt(elementRole.value) === 0) {
    newRoles.push('Admin');
    newRoles.push('Editor');
    newRoles.push('User');
  }

  if(parseInt(elementRole.value) === 1) {
    newRoles.push('Editor');
    newRoles.push('User');
  }

  if(parseInt(elementRole.value) === 2) {
    newRoles.push('User');
  }

  newUser.Roles = newRoles;

  this.service.registerUser(newUser, []).subscribe((data: User) => this.sc = data);
}

deleteUser() {
const elementPassword = (document.getElementById('pasInputDel')) as HTMLSelectElement;
this.users[this.usersTempId].Password = elementPassword.value;
this.service.deleteUser(this.users[this.usersTempId]).subscribe((data: User) => this.sc = data);
}

getUsers() {
this.service.getUsers().subscribe((data: User[]) => this.users = data);
}

updateUser() {
 // const elementLogin = (document.getElementById('updateInputLogin')) as HTMLSelectElement;
  const elementEmail = (document.getElementById('updateInputEmail')) as HTMLSelectElement;
  const elementRole = (document.getElementById('updateInputRole')) as HTMLSelectElement;
  const elementPas = (document.getElementById('updateInputPassword')) as HTMLSelectElement;

  this.oldUser.Password = elementPas.value;
  const newUser = this.oldUser;
 // newUser.Login = elementLogin.value;
  newUser.Email = elementEmail.value;

  const newRoles: string[] = [];

  if(parseInt(elementRole.value) === 0) {
    newRoles.push('Admin');
    newRoles.push('Editor');
    newRoles.push('User');
  }

  if(parseInt(elementRole.value) === 1) {
    newRoles.push('Editor');
    newRoles.push('User');
  }

  if(parseInt(elementRole.value) === 2) {
    newRoles.push('User');
  }

  newUser.Roles = newRoles;

  const model = new UpdateModel();
  model.OldUser = this.oldUser;
  model.NewUser = newUser;
  this.service.updateUser(model).subscribe((data: User) => this.sc = data);
}

changePassword() {
  const elementPas = (document.getElementById('pasInputOld')) as HTMLSelectElement;
  const elementNewPas = (document.getElementById('pasInputNew')) as HTMLSelectElement;
  const elementCofPas = (document.getElementById('pasInputConf')) as HTMLSelectElement;
  this.users[this.usersTempId].Password = elementPas.value;
  this.users[this.usersTempId].NewPassword = elementNewPas.value;
  this.users[this.usersTempId].ConfirmPassword = elementCofPas.value;
  this.service.changeUserPassword(this.users[this.usersTempId]).subscribe((data: User) => this.sc = data);
}

refreshPage() {
window.location.reload();
}

openGreyground() {
document.getElementById('greyground').style.display = 'block';
}

closeGreyground() {
document.getElementById('greyground').style.display = 'none';
}

openAddBox() {
document.getElementById('addbox').style.display = 'block';
}

closeAddBox() {
document.getElementById('addbox').style.display = 'none';
}

openUpdateBox() {
document.getElementById('updatebox').style.display = 'block';
}

closeUpdateBox() {
document.getElementById('updatebox').style.display = 'none';
}

openDeleteBox() {
document.getElementById('deletebox').style.display = 'block';
}

closeDeleteBox() {
document.getElementById('deletebox').style.display = 'none';
}

openPasBox() {
document.getElementById('passwordbox').style.display = 'block';
}

closePasBox() {
document.getElementById('passwordbox').style.display = 'none';
}

}
