import { Component, OnInit } from '@angular/core';

import { AuthServiceService } from '../shared/auth-service.service';

@Component({
  moduleId: module.id,
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() {}

  ngOnInit() {
  }

}
