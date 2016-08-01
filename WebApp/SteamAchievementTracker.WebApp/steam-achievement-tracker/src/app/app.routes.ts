import { provideRouter, RouterConfig } from '@angular/router';

import { GameDetailsRoutes } from './game-details/game-details.routes';
import { DashboardRoutes } from './dashboard/dashboard.routes';
import { AppComponent } from './app.component';

import { LoginComponent } from './login/login.component';

export const APP_ROUTES: RouterConfig = [
  ...DashboardRoutes,
  ...GameDetailsRoutes,
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'dashboard' } //catch any unfound routes and redirect to home page
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(APP_ROUTES)
]