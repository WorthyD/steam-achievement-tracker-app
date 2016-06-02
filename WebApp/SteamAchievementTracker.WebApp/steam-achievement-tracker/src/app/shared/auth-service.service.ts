
import {  Http } from '@angular/http';
import { Injectable } from '@angular/core';

import 'rxjs/add/operator/toPromise';


@Injectable()
export class AuthServiceService {

    constructor(private http: Http) { }

    private baseUrl = "http://localhost/sat/";


    login() {
        console.log('success');
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
