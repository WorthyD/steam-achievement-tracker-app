import { Component, OnInit, Input } from '@angular/core';
import {IGame} from '../services/models/';
import { Router } from '@angular/router';

@Component({
  moduleId: module.id,
  selector: 'game-list',
  templateUrl: 'game-list.component.html',
  styleUrls: ['game-list.component.css']
})
export class GameListComponent implements OnInit {

  @Input() games: IGame[] = [];
  @Input() title: string = "";
  constructor(private router: Router) {  
    console.log('game list constructing');
  }

  ngOnInit() {
  }

  gotoDetail(game:IGame){
    let link = ['/game-details', game.appID];
    this.router.navigate(link);
  }

}
