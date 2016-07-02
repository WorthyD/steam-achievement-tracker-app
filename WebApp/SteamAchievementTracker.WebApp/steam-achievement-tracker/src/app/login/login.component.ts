import { Component, OnInit, EventEmitter, Output } from '@angular/core';

import { AuthServiceService } from '../shared/auth-service.service';

import { UserService } from '../shared/user.service';

@Component({
    moduleId: module.id,
    selector: 'app-login',
    providers: [AuthServiceService ],
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.css']
})
export class LoginComponent implements OnInit {
    @Output() loggedIn = new EventEmitter<boolean>();

    constructor(private authServiceService: AuthServiceService) { }

    userId = '76561198025095151';


    login() {
        this.authServiceService.manualLogin(this.userId);
        this.loggedIn.emit(true);
    }

    ngOnInit() {
    }

}
