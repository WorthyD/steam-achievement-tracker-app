import { Injectable } from '@angular/core';
import {Http, Response } from '@angular/http';

import { BaseServiceService  } from './base-service.service';
import {IPlayerProfile, IRequestSettings} from './models/';

import { Observable } from 'rxjs/Observable';
import {Observer} from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Injectable()
export class PlayerProfileService {

    private profile: IPlayerProfile;
    constructor(private http: Http, private base: BaseServiceService) { }

    /*
        getProfile(steamId: string): Observable<IPlayerProfile> {
    
            var settings: IRequestSettings = {
                url: '/playerprofile/' + steamId,
                method: 'get',
                data: {}
            }
                return this.http.get(settings.url)
                .map((res: Response) => {
                    this.profile = res.json();
                    return this.profile;
                }).catch(this.base.handleError);
    
        }
        */

    getProfile(steamId: string): Promise<IPlayerProfile> {
        return this.http.get(this.base.baseUrl + '/playerprofile/' + steamId)
            .toPromise()
            .then(response => response.json())
            .catch(this.base.handleError);

    }

}
