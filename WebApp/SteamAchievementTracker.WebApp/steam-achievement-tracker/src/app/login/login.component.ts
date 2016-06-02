import { Component, OnInit } from '@angular/core';

import { AuthServiceService } from '../shared/auth-service.service';

@Component({
  moduleId: module.id,
  selector: 'app-login',
  providers: [AuthServiceService],  
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authServiceService: AuthServiceService ) {}

  onClickMe() {
      console.log('works'); 
      this.authServiceService.login();
  }

  ngOnInit() {
  }

}
