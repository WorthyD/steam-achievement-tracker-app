import { Component, OnInit } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BaseServiceService  } from './services/base-service.service';
import { Subject }    from 'rxjs/Subject';

import { AuthServiceService } from './shared/auth-service.service'
import { UserService } from './shared/user.service'
import { ROUTER_DIRECTIVES } from '@angular/router';
import { APP_PROVIDERS } from './app.providers';

@Component({
  moduleId: module.id,
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
    directives: [LoginComponent, DashboardComponent, ROUTER_DIRECTIVES],
    providers: [ APP_PROVIDERS] })
export class AppComponent implements OnInit {
    title = 'steam-achievement-tracker works!';
    userId = '';
    isLoggedIn = false;

    constructor(private authService: AuthServiceService, private userService : UserService) {
        console.log('AppComponent Constructor');
    }

    ngOnInit() {
        console.log('Initing app');

        this.authService.activate();
        this.isLoggedIn = this.userService.isLoggedIn();
        this.userId = this.userService.getUserId();
    }



    loggedIn(isLogged: boolean) {
        console.log('Logged In Worked');
        this.isLoggedIn = isLogged;
        this.userId = this.userService.getUserId();
    }


}
