/* tslint:disable:no-unused-variable */

import {
  beforeEach, beforeEachProviders,
  describe, xdescribe,
  expect, it, xit,
  async, inject
} from '@angular/core/testing';
import { RecentGamesService } from './recent-games.service';

describe('RecentGames Service', () => {
  beforeEachProviders(() => [RecentGamesService]);

  it('should ...',
      inject([RecentGamesService], (service: RecentGamesService) => {
    expect(service).toBeTruthy();
  }));
});
