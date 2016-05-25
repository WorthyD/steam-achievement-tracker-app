import {
  beforeEachProviders,
  it,
  describe,
  expect,
  inject
} from '@angular/core/testing';
import { AuthServiceService } from './auth-service.service';

describe('AuthService Service', () => {
  beforeEachProviders(() => [AuthServiceService]);

  it('should ...',
      inject([AuthServiceService], (service: AuthServiceService) => {
    expect(service).toBeTruthy();
  }));
});
