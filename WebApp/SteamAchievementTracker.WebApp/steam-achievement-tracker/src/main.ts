import { bootstrap } from '@angular/platform-browser-dynamic';

import { HTTP_PROVIDERS } from '@angular/http';

import { enableProdMode } from '@angular/core';

//import {UserService} from './app/shared/user.service';
import { SteamAchievementTrackerAppComponent, environment } from './app/';

if (environment.production) {
  enableProdMode();
}

//bootstrap(SteamAchievementTrackerAppComponent, [HTTP_PROVIDERS, UserService]);
bootstrap(SteamAchievementTrackerAppComponent, [HTTP_PROVIDERS]);

  