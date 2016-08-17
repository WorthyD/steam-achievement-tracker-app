import {RouterConfig} from '@angular/router';
import { LibraryComponent } from './library.component';
import { AuthGuard} from '../shared/utils/auth.guard';

export const LibraryRoutes: RouterConfig = [{
    path: 'library',
    component: LibraryComponent,
    canActivate: [AuthGuard]
}];