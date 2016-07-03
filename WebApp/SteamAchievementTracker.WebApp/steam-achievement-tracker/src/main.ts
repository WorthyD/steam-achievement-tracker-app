import { bootstrap } from '@angular/platform-browser-dynamic';

import { HTTP_PROVIDERS } from '@angular/http';

import { enableProdMode } from '@angular/core';

//import {UserService} from './app/shared/user.service';
import { AppComponent, environment } from './app/';

if (environment.production) {
  enableProdMode();
}

//bootstrap(SteamAchievementTrackerAppComponent, [HTTP_PROVIDERS, UserService]);
bootstrap(AppComponent, [HTTP_PROVIDERS]);

  