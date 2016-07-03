import { Component } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { BaseServiceService  } from './services/base-service.service';
import { Subject }    from 'rxjs/Subject';


import { APP_PROVIDERS } from './app.providers';

@Component({
  moduleId: module.id,
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
    directives: [LoginComponent, ProfileComponent],
    providers: [ APP_PROVIDERS] 
})
export class AppComponent {
    title = 'steam-achievement-tracker works!';




    isLoggedIn = false;

    loggedIn(isLogged: boolean) {
        console.log('Logged In Worked');
        this.isLoggedIn = isLogged;
    }


}
