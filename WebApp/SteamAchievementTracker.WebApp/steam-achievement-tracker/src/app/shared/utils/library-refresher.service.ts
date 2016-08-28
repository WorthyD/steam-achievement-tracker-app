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
        this.libService.getLibrary().subscribe((x: IGame[]) => {
            this.gameLibrary = x;
        });

    }

    startLibraryRefresh() {
        if (!this.gameLibrary) {
            this.process = true;
            this.refresh();
        } else {
            console.log('library not found');
        }
    }
    refresh() {
        var base = this;
        var p1 = new Promise(this.updateGame);
        p1.then(function () {

            if (base.process === true) {
                base.refresh();
            }
        });
    }

    updateGame(resolve, reject) {
        //get and update game
        let games = this.gameLibrary.filter((game) => game.readyForRefresh == true);

        if (games.length > 0) {
            let nextGame = games[0];
            this.gameService.getAchievementsForGame(nextGame).then(function () {

                resolve();
            });

        } else {
            this.process = false;
            resolve();
        }



    }

}
