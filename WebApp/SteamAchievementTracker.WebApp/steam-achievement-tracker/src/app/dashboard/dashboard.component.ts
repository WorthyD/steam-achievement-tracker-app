import { Component, OnInit } from '@angular/core';
import { ProfileComponent } from '../profile/profile.component';

import {IGame} from '../services/models/game';
import {RecentGamesService} from '../services/recent-games.service';
import {PlayerLibraryService} from '../services/player-library.service';


@Component({
  moduleId: module.id,
  selector: 'app-dashboard',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.css'],
  directives: [ProfileComponent],
  providers: [RecentGamesService]
})
export class DashboardComponent implements OnInit {
  recentGames: IGame[];

  constructor(private recentGameService: RecentGamesService, private playerLibraryService: PlayerLibraryService) { }

  ngOnInit() {
    this.loadRecentGames();
  }

  loadRecentGames() {

    this.playerLibraryService.getLibrary().subscribe((x: IGame[]) => {
    //this.recentGameService.getRecentGames().subscribe((x: IGame[]) => {
      console.log('-------dashboard-------');
      console.log(x);
      this.recentGames = x;
    });

  }

}
