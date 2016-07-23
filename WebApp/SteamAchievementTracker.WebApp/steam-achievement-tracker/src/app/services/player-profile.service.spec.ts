import {
  beforeEachProviders,
  it,
  describe,
  expect,
  inject
} from '@angular/core/testing';
import { PlayerProfileService } from './player-profile.service';
import  { BaseServiceService  } from './base-service.service';


/*
describe('PlayerProfile Service', () => {
  beforeEachProviders(() => [BaseServiceService, PlayerProfileService]);

  it('should ...',
      inject([PlayerProfileService], (service: PlayerProfileService) => {
    expect(service).toBeTruthy();
  }));
});
*/