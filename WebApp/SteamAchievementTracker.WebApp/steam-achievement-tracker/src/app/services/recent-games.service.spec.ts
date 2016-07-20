/* tslint:disable:no-unused-variable */

import {
  beforeEach, beforeEachProviders,
  describe, xdescribe,
  expect, it, xit,
  async, inject
} from '@angular/core/testing';

import { BaseServiceService  } from './base-service.service';
import { RecentGamesService } from './recent-games.service';
import { PlayerLibraryService  } from './player-library.service';

describe('RecentGames Service', () => {
  beforeEachProviders(() => [BaseServiceService, PlayerLibraryService,  RecentGamesService]);

  it('should ...',
      inject([RecentGamesService], (service: RecentGamesService) => {
    expect(service).toBeTruthy();
  }));
});
