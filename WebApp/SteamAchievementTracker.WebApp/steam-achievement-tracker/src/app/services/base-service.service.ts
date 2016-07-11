import { Injectable } from '@angular/core';
import {  Http, Response} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import {Observer} from 'rxjs/Observer';

import {IRequestSettings} from './models/request-settings';
import { environment } from '../';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class BaseServiceService {

    baseUrl = environment.baseUrl;
    constructor(private http: Http) {
        console.log('constructing base service');

    }



    makeCall(settings: IRequestSettings): any {
        if (settings.method == 'get') {
            // return this.http.get(this.baseUrl + settings.url).then(res => {
            //     return res;
            // }).catch(this.handleError);
        }

    }
    /*
        handleError(error: any) {
            console.error(error);
            return Observable.throw(error.json().error || 'Server error');
        }
    */
    createObservable(data: any): Observable<any> {
        return Observable.create((observer: Observer<any>) => {
            observer.next(data);
            observer.complete();
        });
    }

    handleError(error: any) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }

    handleObsError(error: any) {


        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
