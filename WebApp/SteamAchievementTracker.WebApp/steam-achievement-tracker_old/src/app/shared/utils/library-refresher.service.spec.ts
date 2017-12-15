/* tslint:disable:no-unused-variable */

import { addProviders, async, inject } from '@angular/core/testing';
import { LibraryRefresherService } from './library-refresher.service';

describe('Service: LibraryRefresher', () => {
  beforeEach(() => {
    addProviders([LibraryRefresherService]);
  });

  it('should ...',
    inject([LibraryRefresherService],
      (service: LibraryRefresherService) => {
        expect(service).toBeTruthy();
      }));
});
