import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

import {UserService} from '../user.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private user: UserService) { 
        console.log("ACTIVATING");
    }

    canActivate() {

        if(this.user.isLoggedIn()){
            return true;
        }

        this.router.navigate(['/login']);
        return false;
    }
}