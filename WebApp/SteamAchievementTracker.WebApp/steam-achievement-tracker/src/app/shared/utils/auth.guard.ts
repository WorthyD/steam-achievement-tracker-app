import { Injectable } from '@angular/core';
import { Router,
    RouterStateSnapshot,
     CanActivate } from '@angular/router';

import {UserService} from '../user.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private user: UserService, state: RouterStateSnapshot) { 
    //constructor(private router: Router) { 
        console.log("ACTIVATING");
    }

    canActivate() {

        if(this.user.isLoggedIn()){
            return true;
        }
            // Store the attempted URL for redirecting
//    this..redirectUrl = state.url;


        this.router.navigate(['/login']);
        return false;
    }
}