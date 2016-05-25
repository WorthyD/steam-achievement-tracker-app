import { Component } from '@angular/core';
import { LoginComponent } from './login/login.component';

@Component({
  moduleId: module.id,
  selector: 'steam-achievement-tracker-app',
  templateUrl: 'steam-achievement-tracker.component.html',
  styleUrls: ['steam-achievement-tracker.component.css'],
  directives: [LoginComponent]
})
export class SteamAchievementTrackerAppComponent {
  title = 'steam-achievement-tracker works!';
}
