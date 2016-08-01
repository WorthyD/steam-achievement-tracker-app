import { bootstrap } from '@angular/platform-browser-dynamic';

import { HTTP_PROVIDERS } from '@angular/http';

import { enableProdMode } from '@angular/core';

//import {UserService} from './app/shared/user.service';
import { AppComponent, environment } from './app/';
import { APP_ROUTER_PROVIDERS } from './app/app.routes';
import {AuthGuard} from './app/shared/utils/auth.guard';
import {APP_PROVIDERS} from './app/app.providers';

if (environment.production) {
  enableProdMode();
}

//bootstrap(SteamAchievementTrackerAppComponent, [HTTP_PROVIDERS, UserService]);
bootstrap(AppComponent, [HTTP_PROVIDERS, APP_ROUTER_PROVIDERS]);
//bootstrap(AppComponent, [APP_PROVIDERS, APP_ROUTER_PROVIDERS]);

  