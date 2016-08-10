
import { Injectable } from '@angular/core';
import {Http, Response } from '@angular/http';


import { BaseServiceService  } from './base-service.service';
import {IGame, IRequestSettings} from './models/';

import {PlayerLibraryService} from './player-library.service';
import {UserService} from '../shared/user.service';

import { Observable } from 'rxjs/Observable';

import {Observer} from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

@Injectable()
export class GameDetailsService {

    constructor(private http: Http, private base: BaseServiceService, private libservice: PlayerLibraryService) {
    }


    getAchievementsForGame(appId): Promise<IGame> {
        //api/gameachievement/231740?steamId=76561198025095151
        let steamID = this.base.getUserId();
        return this.http.get(this.base.baseUrl + '/getachievement/' + appId + '?steamId=' + steamID).toPromise().then((res: Response) => {

            let game: IGame = res.json();

            this.libservice.updateGame(game);

            return game;

        });


    }

}
