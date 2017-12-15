/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GameDetailsService } from './game-details.service';

describe('GameDetailsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GameDetailsService]
    });
  });

  it('should ...', inject([GameDetailsService], (service: GameDetailsService) => {
    expect(service).toBeTruthy();
  }));
});
