import { Injectable } from '@angular/core';
import {Http, Response } from '@angular/http';

import { BaseServiceService  } from './base-service.service';
import { PlayerLibraryService  } from './player-library.service';
import {IGame, IRequestSettings} from './models/';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class RecentGamesService {

  recentGames: IGame[];
  constructor(private http: Http, private base: BaseServiceService, private playerLibrary: PlayerLibraryService) {

  }

  getRecentGames(): Promise<IGame[]>{
    let steamID = this.base.getUserId();

    if (!this.recentGames){
      return this.http.get(this.base.baseUrl + '/recentgames/' + steamID)
              .toPromise().then((res: Response) =>{
                //console.log(res.json());
                console.log('got recent games');
                 return this.playerLibrary.getGamesByIds(res.json()).then(x =>{
                   console.log('---- Game by Ids------------');
                   console.log(x);
                   return x;
                 });

              });//.catch(this.base.handleObsError);
    }else{
      //return this.base.createObservable(this.recentGames);
    }
  }
}
