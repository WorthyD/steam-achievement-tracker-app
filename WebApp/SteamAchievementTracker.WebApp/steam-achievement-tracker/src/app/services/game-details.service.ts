import { Injectable } from '@angular/core';
import {Http, Response } from '@angular/http';


import { BaseServiceService  } from './base-service.service';
import {IGame, IRequestSettings} from './models/';

import {UserService} from '../shared/user.service';

import { Observable } from 'rxjs/Observable';
import {Observer} from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

@Injectable()
export class GameDetailsService {

  constructor(private http: Http, private base: BaseServiceService) {
    console.log('constructing player lib service');
  }

  getAchievementsForGame(appId): Promise<IGame>{

    return null;
  }

}
