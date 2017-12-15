import { Injectable } from '@angular/core';
import {Observable, Observer} from 'rxjs';


@Injectable()
export class BaseServiceService {

  baseUrl = 'http://sat.localhost/api';
  constructor() { }
   createObservable(data: any): Observable<any> {
        return Observable.create((observer: Observer<any>) => {
            observer.next(data);
            observer.complete();
        });
    }

    handleError(error: any) {
        return Promise.reject(error.message || error);
    }

    handleObsError(error: any) {
        return Observable.throw(error.json().error || 'Server error');
    }
}
