import {
  beforeEachProviders,
  it,
  describe,
  expect,
  inject
} from '@angular/core/testing';
import { AuthServiceService } from './auth-service.service';
import { HTTP_PROVIDERS } from '@angular/http';

describe('AuthService Service', () => {
  beforeEachProviders(() => [HTTP_PROVIDERS, AuthServiceService]);

  it('should ...',
      inject([AuthServiceService], (service: AuthServiceService) => {
    expect(service).toBeTruthy();
  }));
});
