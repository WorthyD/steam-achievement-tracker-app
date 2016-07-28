import {RouterConfig} from '@angular/router';
import { GameDetailsComponent } from './game-details.component';

export const GameDetailsRoutes: RouterConfig =[{
    path:'game-details/:id',
    component: GameDetailsComponent
}];