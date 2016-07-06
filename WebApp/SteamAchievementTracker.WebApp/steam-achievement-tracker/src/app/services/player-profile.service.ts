import { Injectable } from '@angular/core';
import {Http,  Response } from '@angular/http';

import { BaseServiceService  } from './base-service.service';
import {IPlayerProfile, IRequestSettings} from './models/';

@Injectable()
export class PlayerProfileService {

    private profile: IPlayerProfile; 
    constructor(private base: BaseServiceService) { }


    getProfile(steamId: number): IPlayerProfile {

        var settings: IRequestSettings = {
            url: '/playerprofile/' + steamId,
            method: 'get',
            data: {}
        }
         this.base.makeCall(settings).then(profile =>
            this.profile = profile);

         return this.profile;
    }

}
