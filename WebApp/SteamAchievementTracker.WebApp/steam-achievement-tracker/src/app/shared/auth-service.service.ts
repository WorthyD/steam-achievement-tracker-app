
import {  Http } from '@angular/http';
import { Injectable, OnInit, EventEmitter } from '@angular/core';
import {  CookieService } from 'angular2-cookie/core';

import 'rxjs/add/operator/toPromise';

import {UserService} from './user.service';
import {PlayerProfileService} from '../services/player-profile.service';

import { Router } from '@angular/router';

@Injectable()
export class AuthServiceService {
    private cookieName = "SteamId";

    emitter = new EventEmitter<boolean>();


    constructor(private http: Http, private userService: UserService, private cookies: CookieService, private router: Router, private profileService: PlayerProfileService) {
        this.activate();
    }

    private baseUrl = "http://localhost/sat/";

    activate() {
        console.log('Init auth service');
        var userId = this.cookies.get(this.cookieName);
        if (userId) {
            this.manualLogin(userId);
        }
    }



    manualLogin(userID: string) {

        console.log('manal login');
        console.log(userID);

        this.userService.create(userID);
        this.cookies.put(this.cookieName, userID);
        this.emitter.next(true);
    }



    login(userID: string) {
        console.log('userID ' + userID);

        var base = this;
        var p1 = new Promise(function (resolve, reject) {
            base.profileService.getProfile(userID).then(profile => {
                console.log('userID after ' + profile.steamIdStr);

                base.manualLogin(profile.steamIdStr);
                console.log('success');
                resolve();
            });
        });
        return p1;

        /*
        return this.http.get(this.baseUrl + 'api/Account/ExternalLogin?provider=steam')
            .toPromise()
            .then(response => console.log(response.json().data))
            .catch(this.handleError);
        */
    }

    logout() {
        this.cookies.remove(this.cookieName);
        this.userService.destroy();
    }

    checkCredentials(): boolean {
        if (this.userService.isLoggedIn() == false) {
            console.log('going to login');
            this.router.navigate(['login']);
            return false;
        }
        return true;
    }

    private handleError(error: any) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }


}
