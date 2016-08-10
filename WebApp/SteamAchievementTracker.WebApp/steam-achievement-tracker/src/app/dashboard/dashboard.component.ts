import { Component, OnInit } from '@angular/core';
import { ProfileComponent } from '../profile/profile.component';
import {GameListComponent} from '../game-list/';

import {IGame} from '../services/models/game';
import {RecentGamesService} from '../services/recent-games.service';
import {PlayerLibraryService} from '../services/player-library.service';

import { AuthServiceService } from '../shared/auth-service.service'
import 'rxjs/add/operator/toPromise';
@Component({
  moduleId: module.id,
  selector: 'app-dashboard',
  templateUrl: 'dashboard.component.html',
//  styleUrls: ['dashboard.component.css'],
  directives: [ProfileComponent, GameListComponent],
  providers: [RecentGamesService]
})
export class DashboardComponent implements OnInit {
  recentGames: IGame[];

  constructor(private recentGameService: RecentGamesService, private authService: AuthServiceService) { }

  ngOnInit() {
   /// if (this.authService.checkCredentials()) {
      this.loadRecentGames();

   // }
  }

  loadRecentGames() {

    //this.playerLibraryService.getLibrary().subscribe((x: IGame[]) => {
    this.recentGameService.getRecentGames().then((x: IGame[]) => {
      this.recentGames = x;
    });

  }

}
