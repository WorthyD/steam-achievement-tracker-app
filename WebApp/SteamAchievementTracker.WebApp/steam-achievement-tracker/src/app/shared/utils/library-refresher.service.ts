import { Injectable } from '@angular/core';
import {PlayerLibraryService} from '../../services/player-library.service';

@Injectable()
export class LibraryRefresherService {

    constructor(private libService: PlayerLibraryService) {


    }

    startLibraryRefresh() {
        //
    }

}
