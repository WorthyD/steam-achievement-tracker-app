import {RouterConfig} from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { AuthGuard} from '../shared/utils/auth.guard';

export const DashboardRoutes: RouterConfig = [{
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
}];