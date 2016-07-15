import {
  beforeEachProviders,
  beforeEach,
  it,
  describe,
  expect,
  inject
} from '@angular/core/testing';
import { BaseServiceService } from './base-service.service';
import {UserService} from '../shared/user.service';

describe('BaseService Service', () => {
  let user;

  beforeEachProviders(() => [BaseServiceService, UserService]);

  
  beforeEach(inject([UserService], s => {
    user = s;
    user.create('user');
  }));
  


  it('should build',
      inject([BaseServiceService], (service: BaseServiceService) => {
    expect(service).toBeTruthy();
  }));
    it('get user id',
      inject([BaseServiceService], (service: BaseServiceService) => {
        let id = user.getUserId();
        expect(id).toEqual('user');
  }));

});

