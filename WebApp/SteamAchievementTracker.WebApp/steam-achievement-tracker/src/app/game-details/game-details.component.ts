import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import {IGame} from '../services/models/';

import {PlayerLibraryService} from '../services/player-library.service';

@Component({
    moduleId: module.id,
    selector: 'app-game-details',
    templateUrl: 'game-details.component.html',
    //styleUrls: ['game-details.component.css']
})
export class GameDetailsComponent implements OnInit {

    private sub: any;
    appId;
    constructor(private router: Router, private route: ActivatedRoute, private playerLib: PlayerLibraryService) { }

    ngOnInit() {
        console.log(this.route.params);
        console.log(this.router);
        const id = this.route.params['id'];
        this.appId = id;
        this.sub = this.route.params.subscribe(params => {
            let id = +params['id']; // (+) converts string 'id' to a number
            console.log(id);
            //this.service.getHero(id).then(hero => this.hero = hero);

            //Get game details

            console.log('getting id');
            // if no achievements get more
            this.playerLib.getGameByID(id).then((game: IGame) => {
                console.log('in complete');
                console.log(game);

            });


        });

    }

}
