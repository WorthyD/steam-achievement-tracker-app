import { Component } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { BaseServiceService  } from './services/base-service.service';
import { Subject }    from 'rxjs/Subject';


import { APP_PROVIDERS } from './app.providers';

@Component({
    moduleId: module.id,
    selector: 'steam-achievement-tracker-app',
    templateUrl: 'steam-achievement-tracker.component.html',
    styleUrls: ['steam-achievement-tracker.component.css'],
    directives: [LoginComponent, ProfileComponent],
    providers: [ APP_PROVIDERS] 
})
export class SteamAchievementTrackerAppComponent {
    title = 'steam-achievement-tracker works!';




    isLoggedIn = false;

    loggedIn(isLogged: boolean) {
        console.log('Logged In Worked');
        this.isLoggedIn = isLogged;
    }



}
