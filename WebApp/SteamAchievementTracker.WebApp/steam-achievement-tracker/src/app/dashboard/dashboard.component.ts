import { Component, OnInit } from '@angular/core';
import { ProfileComponent } from '../profile/profile.component';

import {IGame} from '../services/models/game';
import {RecentGamesService} from '../services/recent-games.service';


@Component({
  moduleId: module.id,
  selector: 'app-dashboard',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.css'],
  directives: [ProfileComponent],
})
export class DashboardComponent implements OnInit {
  recentGames: IGame[];

  constructor(private recentGameService: RecentGamesService) { }

  ngOnInit() {
    this.loadRecentGames();
  }

  loadRecentGames() {

    this.recentGameService.getRecentGames().subscribe((x: IGame[]) => {
      this.recentGames = x;
    });

  }

}
