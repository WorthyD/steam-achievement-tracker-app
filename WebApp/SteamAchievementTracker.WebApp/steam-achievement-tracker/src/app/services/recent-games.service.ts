import { Injectable } from '@angular/core';
import {Http, Response } from '@angular/http';

import { BaseServiceService  } from './base-service.service';
import { PlayerLibraryService  } from './player-library.service';
import {IGame, IRequestSettings} from './models/';

import { Observable } from 'rxjs/Observable';

@Injectable()
export class RecentGamesService {

  recentGames: IGame[];
  constructor(private http: Http, private base: BaseServiceService, private playerLibrary: PlayerLibraryService) {

  }

  getRecentGames(): Observable<IGame[]>{
    let steamID = this.base.getUserId();

    if (!this.recentGames){
      return this.http.get(this.base.baseUrl + '/recentgames/' + steamID)
              .map((res: Response) =>{
                 return this.playerLibrary.getGamesByIds(res.json()).map(x =>{
                   console.log('---- Game by Ids------------');
                   console.log(x);
                   return x;
                 });

              }).catch(this.base.handleObsError);
    }else{
      return this.base.createObservable(this.recentGames);
    }
  }
}
