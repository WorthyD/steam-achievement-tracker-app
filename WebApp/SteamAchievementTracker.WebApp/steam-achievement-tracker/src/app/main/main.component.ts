import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';
import { AuthServiceService } from '../shared/auth-service.service'
import { DashboardComponent } from '../dashboard/dashboard.component';
import { LoginComponent } from '../login/login.component';
import { UserService} from '../shared/user.service';

import {LibraryRefresherService} from '../shared/utils/library-refresher.service';


import {Subject} from 'rxjs/Subject';


@Component({
    moduleId: module.id,
    selector: 'app-main',
    templateUrl: 'main.component.html',
    directives: [ROUTER_DIRECTIVES],
    //  styleUrls: ['main.component.css']
})
export class MainComponent implements OnInit {

    private logInEventSource = new Subject<boolean>();
    loginEvent$ = this.logInEventSource.asObservable();

    constructor(private user: AuthServiceService, private router: Router, private refresher: LibraryRefresherService) {

        console.log('subscribing');
        user.emitter.subscribe((data) => {
            console.log('============================= logging in via subscribe =====================================');

            this.refresher.init();
            //this.refresher.startLibraryRefresh();

        });

    }

    logOut() {
        console.log('logging out');
        this.user.logout();
        this.router.navigate(['/login']);
    }

    ngOnInit() {
    }

}
