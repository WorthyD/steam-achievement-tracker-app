import { Component, OnInit } from '@angular/core';

import {IGame} from '../services/models/game';
import {PlayerLibraryService} from '../services/player-library.service';
import {GameListComponent} from '../game-list/';

@Component({
    moduleId: module.id,
    selector: 'app-library',
    directives: [GameListComponent],
    templateUrl: 'library.component.html',
    //styleUrls: ['library.component.css']
})
export class LibraryComponent implements OnInit {
    gameLibrary: IGame[];

    constructor(private libService: PlayerLibraryService) { }

    ngOnInit() {
        this.loadLibrary();
    }

    loadLibrary() {
        this.libService.getLibrary().subscribe((x: IGame[]) => {
            console.log(x);
            this.gameLibrary = x;
        });
    }

}
