import {
  beforeEachProviders,
  it,
  describe,
  expect,
  inject
} from '@angular/core/testing';
import { BaseServiceService } from './base-service.service';

describe('BaseService Service', () => {
  beforeEachProviders(() => [BaseServiceService]);

  it('should ...',
      inject([BaseServiceService], (service: BaseServiceService) => {
    expect(service).toBeTruthy();
  }));
});

