import { Component, OnInit } from '@angular/core';
import { RolesService } from './roles.service';
import { HttpClient } from '@angular/common/http';
import { Role } from './Models/Role';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css'],
  providers: [RolesService]
})
export class RolesComponent implements OnInit {

  constructor(private service: RolesService, http: HttpClient) {
  }

  public roles: Role[];
  sc: Role;
  public currentRole: string;
  tempId: number;

  ngOnInit() {
    this.closeGreyground();
    this.closeAddBox();
    this.closeUpdateBox();
    this.closeDeleteBox();
    this.getRoles();
    this.tempId = 0;
    this.roles[this.tempId] = new Role();
  }

  getRoles() {
    this.roles = [];
    this.service.getRoles().subscribe((data: Role[]) => (this.roles = data));
  }

  getCurrentRole() {
    const element = (document.getElementById('roles-list')) as HTMLSelectElement;
    const select = element.selectedIndex;
    const option = element.options[select];
    this.currentRole = option.value;
    this.tempId = parseInt(this.currentRole);

    const elementUpdate = (document.getElementById('updateInputRole')) as HTMLSelectElement;
    elementUpdate.value = this.roles[this.tempId].Name;
  }

  updateRole() {
    const element = (document.getElementById('updateInputRole')) as HTMLSelectElement;
    this.roles[this.tempId].Name = element.value;
    element.value = '';
    this.service.updateRole(this.roles[this.tempId]).subscribe((data: Role) => this.sc = data);
  }

  addRole() {
    const element = (document.getElementById('addInputRole')) as HTMLSelectElement;
    const newCountry = new Role();
    newCountry.Name = element.value;
    element.value = '';
    this.service.addRole(newCountry).subscribe((data: Role) => this.sc = data);
  }

  deleteRole() {
    this.service.deleteRole(this.roles[this.tempId].Id).subscribe((data: Role) => this.sc = data);
  }

  refreshPage() {
    window.location.reload();
  }

  openGreyground() {
    document.getElementById('greygroundR').style.display = 'block';
  }

   closeGreyground() {
    document.getElementById('greygroundR').style.display = 'none';
  }

  openAddBox() {
    document.getElementById('addboxR').style.display = 'block';
  }

   closeAddBox() {
    document.getElementById('addboxR').style.display = 'none';
  }

  openUpdateBox() {
    document.getElementById('updateboxR').style.display = 'block';
  }

   closeUpdateBox() {
    document.getElementById('updateboxR').style.display = 'none';
  }

  openDeleteBox() {
    document.getElementById('deleteboxR').style.display = 'block';
  }

   closeDeleteBox() {
    document.getElementById('deleteboxR').style.display = 'none';
  }

}
