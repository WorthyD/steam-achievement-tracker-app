/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PlayerLibraryService } from './player-library.service';

describe('PlayerLibraryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PlayerLibraryService]
    });
  });

  it('should ...', inject([PlayerLibraryService], (service: PlayerLibraryService) => {
    expect(service).toBeTruthy();
  }));
});
