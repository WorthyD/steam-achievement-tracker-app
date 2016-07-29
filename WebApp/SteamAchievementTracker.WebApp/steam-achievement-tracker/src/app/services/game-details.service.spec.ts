/* tslint:disable:no-unused-variable */

import { addProviders, async, inject } from '@angular/core/testing';
import { GameDetailsService } from './game-details.service';

describe('Service: GameDetails', () => {
  beforeEach(() => {
    addProviders([GameDetailsService]);
  });

  it('should ...',
    inject([GameDetailsService],
      (service: GameDetailsService) => {
        expect(service).toBeTruthy();
      }));
});
