/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RecentGameService } from './recent-game.service';

describe('RecentGameService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecentGameService]
    });
  });

  it('should ...', inject([RecentGameService], (service: RecentGameService) => {
    expect(service).toBeTruthy();
  }));
});
