import { HTTP_PROVIDERS } from '@angular/http';
import {UserService} from './shared/user.service';
import {AuthServiceService} from './shared/auth-service.service';
import {BaseServiceService} from './services/base-service.service';
import {PlayerLibraryService} from './services/player-library.service';
import {GameDetailsService} from './services/game-details.service'
import {  CookieService } from 'angular2-cookie/core';
import {AuthGuard} from './shared/utils/auth.guard';

import {LibraryRefresherService} from './shared/utils/library-refresher.service';
//import { Sorter } from './shared/utils/sorter';
//import { DataService } from './shared/services/data.service';
//import { TrackByService } from './shared/services/trackby.service';

export const APP_PROVIDERS = [
    // AuthGuard,
    AuthServiceService,
    //UserService,
    HTTP_PROVIDERS,
    CookieService,
    BaseServiceService,
    PlayerLibraryService,
    LibraryRefresherService,
    GameDetailsService
];