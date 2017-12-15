import { Component, OnInit, EventEmitter, Output } from '@angular/core';

import { AuthServiceService } from '../shared/auth-service.service';

import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';
@Component({
    moduleId: module.id,
    selector: 'app-login',
    templateUrl: 'login.component.html'
//    styleUrls: ['login.component.css']
})
export class LoginComponent implements OnInit {
    @Output() loggedIn = new EventEmitter<boolean>();

    constructor(private authServiceService: AuthServiceService, private router: Router) {

    }

    userId = '76561198025095151';


    login() {
        console.log('loggin in ');
        console.log(this.userId);
        var base = this
        this.authServiceService.login(this.userId).then(() => {
            base.loggedIn.emit(true);
            base.redirect();
        });
    }

    redirect() {
        this.router.navigate(['/dashboard']);
    }

    ngOnInit() {
    }

}
