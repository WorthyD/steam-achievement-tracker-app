import { Injectable } from '@angular/core';
import {PlayerLibraryService} from '../../services/player-library.service';
import {GameDetailsService} from '../../services/game-details.service';
import {IGame} from '../../services/models/game';

@Injectable()
export class LibraryRefresherService {
    private gameLibrary: IGame[];
    private process: boolean;

    constructor(private libService: PlayerLibraryService, private gameService: GameDetailsService) {

    }

    init() {
        var base = this;
        //       var p1 = new Promise(function (resolve, reject) {
        //            console.log('calling new promise');
        /*
        this.libService.getLibrary().subscribe((x: IGame[]) => {
            base.gameLibrary = x;
        });
        */
        //       });
        //      return p1;
    }

    startLibraryRefresh() {
        console.log('Refreshing');
        this.process = true;
        this.refresh();
    }

    refresh() {
        console.log('refreshing');
        var base = this;
        console.log(this.gameLibrary);

        var p1 = new Promise(function (resolve, reject) {

            base.libService.getLibPromise().then((x: IGame[]) => {
                let games = x.filter((game) => game.readyForRefresh == true);
                console.log(JSON.stringify(games[0]));

                if (games.length > 0) {
                    let nextGame = games[0];
                    base.gameService.getAchievementsForGame(nextGame.appID).then(function () {
                        resolve();
                    });

                } else {
                    base.process = false;
                    resolve();
                }
            });

        });
        p1.then(function () {

            if (base.process === true) {
                setTimeout(() => {
                    base.refresh();
                }, 5000);

            }
        });
    }

    stopRefresh() {
        this.process = false;

    }

    updateGame(resolve, reject) {
        console.log('=------------------');
        console.log(this.gameLibrary);
        //get and update game


    }

}
