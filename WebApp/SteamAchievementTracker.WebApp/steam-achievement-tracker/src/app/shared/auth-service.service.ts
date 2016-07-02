
import {  Http } from '@angular/http';
import { Injectable, OnInit } from '@angular/core';
import {  CookieService } from 'angular2-cookie/core';

import 'rxjs/add/operator/toPromise';

import {UserService} from './user.service';

@Injectable()
export class AuthServiceService implements OnInit {
    private cookieName = "SteamId";

    constructor(private http: Http, private userService: UserService, private cookies:CookieService) { }

    private baseUrl = "http://localhost/sat/";

    ngOnInit() {
        var userId = this.cookies.get(this.cookieName);
   
        if (userId) {
            this.manualLogin(userId); 
        }

    }



    manualLogin(userID:string) {
        this.userService.create(userID);
        this.cookies.put(this.cookieName, userID);
    }


    login() {
        console.log('success');
        this.manualLogin('1234');

        
        /*
        return this.http.get(this.baseUrl + 'api/Account/ExternalLogin?provider=steam')
            .toPromise()
            .then(response => console.log(response.json().data))
            .catch(this.handleError);
        */
    }

    private handleError(error: any) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }


}
