import { Injectable } from '@angular/core';
import {Http, Response } from '@angular/http';

import { BaseServiceService  } from './base-service.service';
import { PlayerLibraryService  } from './player-library.service';
import {IGame, IRequestSettings} from './models/';

@Injectable()
export class RecentGamesService {

  constructor(private http: Http, private base: BaseServiceService, private playerLibrary: PlayerLibraryService ) {

  }
  



}
