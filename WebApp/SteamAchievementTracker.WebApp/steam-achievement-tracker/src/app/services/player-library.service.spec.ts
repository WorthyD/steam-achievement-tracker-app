/* tslint:disable:no-unused-variable */

import {
  beforeEach, beforeEachProviders,
  describe, xdescribe,
  expect, it, xit,
  async, inject
} from '@angular/core/testing';
import { PlayerLibraryService } from './player-library.service';

describe('PlayerLibrary Service', () => {
  beforeEachProviders(() => [PlayerLibraryService]);

  it('should ...',
      inject([PlayerLibraryService], (service: PlayerLibraryService) => {
    expect(service).toBeTruthy();
  }));
});
