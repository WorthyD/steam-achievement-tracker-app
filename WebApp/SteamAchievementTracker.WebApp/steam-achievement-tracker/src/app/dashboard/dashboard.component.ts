import { Component, OnInit } from '@angular/core';
import { ProfileComponent } from '../profile/profile.component';
@Component({
  moduleId: module.id,
  selector: 'app-dashboard',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.css'],
   directives: [ProfileComponent],
})
export class DashboardComponent implements OnInit {

  constructor() {}

  ngOnInit() {
  }

}
