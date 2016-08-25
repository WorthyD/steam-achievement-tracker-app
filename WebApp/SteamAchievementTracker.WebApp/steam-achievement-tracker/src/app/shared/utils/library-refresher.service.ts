import { Injectable } from '@angular/core';
import {PlayerLibraryService} from '../../services/player-library.service';
import {IGame} from '../../services/models/game';

@Injectable()
export class LibraryRefresherService {
gameLibrary: IGame[];

    constructor(private libService: PlayerLibraryService) {


    }

    init() {
        this.libService.getLibrary().subscribe((x: IGame[]) => {
            this.gameLibrary = x;
            this.startLibraryRefresh();
        });

    }

    startLibraryRefresh() {
        //
            let games = this.gameLibrary.filter((game) => game.readyForRefresh == true);
            console.log(games.length);
            console.log(games);

    }

}
