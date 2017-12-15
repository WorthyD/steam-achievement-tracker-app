/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PlayerProfileService } from './player-profile.service';

describe('PlayerProfileService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PlayerProfileService]
    });
  });

  it('should ...', inject([PlayerProfileService], (service: PlayerProfileService) => {
    expect(service).toBeTruthy();
  }));
});
