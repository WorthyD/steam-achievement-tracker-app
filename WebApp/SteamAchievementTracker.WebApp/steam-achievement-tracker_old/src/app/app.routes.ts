import { provideRouter, RouterConfig } from '@angular/router';

import { LibraryRoutes } from './library/library.routes';
import { GameDetailsRoutes } from './game-details/game-details.routes';
import { DashboardRoutes } from './dashboard/dashboard.routes';
import { AppComponent } from './app.component';
import {AuthGuard} from './shared/utils/auth.guard';

import {UserService} from './shared/user.service';
import { LoginComponent } from './login/login.component';

export const APP_ROUTES: RouterConfig = [
    ...LibraryRoutes,
    ...DashboardRoutes,
    ...GameDetailsRoutes,
    { path: 'login', component: LoginComponent },
    { path: '**', redirectTo: 'dashboard' } //catch any unfound routes and redirect to home page
];

export const APP_ROUTER_PROVIDERS = [
    provideRouter(APP_ROUTES),
    UserService,
    AuthGuard
]