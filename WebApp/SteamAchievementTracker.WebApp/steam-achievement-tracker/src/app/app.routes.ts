import { provideRouter, RouterConfig } from '@angular/router';

import { GameDetailsRoutes } from './game-details/game-details.routes';
import { DashboardRoutes } from './dashboard/dashboard.routes';

export const APP_ROUTES: RouterConfig = [
  ...DashboardRoutes,
  ...GameDetailsRoutes,
  { path: '**', pathMatch:'full', redirectTo: '/dashboard' } //catch any unfound routes and redirect to home page
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(APP_ROUTES)
]