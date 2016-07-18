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
export class PlayerLibraryService {

  library: IGame[];

  constructor(private http: Http, private base: BaseServiceService) {
    console.log('constructing player lib service');
  }

  getLibrary(): Observable<IGame[]> {
    let steamID = this.base.getUserId();
    if (!this.library) {
      return this.http.get(this.base.baseUrl + '/playerlibrary/' + steamID)
        .map((res: Response) => {
          this.library = res.json();
          return this.library;
        })
        .catch(this.base.handleObsError);

    } else {
      // return this.createObservable(this.customers);
      return this.base.createObservable(this.library);
    }
  }

  getGamesByIds(appIds: number[]): Promise<IGame[]> {
    if (!this.library){
      /*
      return this.getLibrary().toPromise()
            .then((lib : Promise<IGame[]>) => {
               return this.library.filter((game) =>  appIds.indexOf(game.appID) > -1);
            });
           // .then((library) => this.library.filter((game) =>  appIds.indexOf(game.appID) > -1));
           */
          /*
          return this.getLibrary().toPromise().then( x => {
            return null;
          });
          */
            return this.getLibrary().toPromise().then(games => {
                        this.library = games;
                       return this.filterGames(appIds);
            });

    }else{
      return Promise.resolve(this.filterGames(appIds));
    }


  }

  private filterGames(appIds: number[]): IGame[]{
    console.log(appIds);
    const games = this.library.filter((game) =>  appIds.indexOf(game.appID) > -1);
    return (games.length) ? games : null;

  }






}
