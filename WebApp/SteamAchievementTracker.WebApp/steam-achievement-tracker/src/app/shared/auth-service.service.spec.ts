import {
    beforeEachProviders,
    it,
    describe,
    expect,
    inject
} from '@angular/core/testing';
import { AuthServiceService } from './auth-service.service';
import { HTTP_PROVIDERS } from '@angular/http';

import {  CookieService } from 'angular2-cookie/core';
import { UserService } from './user.service';

describe('AuthService Service', () => {
    beforeEachProviders(() => [HTTP_PROVIDERS, CookieService, AuthServiceService, UserService]);

    it('should inject  the component',
        inject([AuthServiceService, UserService], (service: AuthServiceService, userService: UserService) => {
            expect(service).toBeTruthy();
            expect(userService).toBeTruthy();
        })
    );

    it('should login user',
        inject([AuthServiceService, UserService], (service: AuthServiceService, userService: UserService) => {
            service.login();
            expect(userService.isLoggedIn()).toEqual(true);
        })
    );

    it('should manually login user',
        inject([AuthServiceService, UserService], (service: AuthServiceService, userService: UserService) => {
            service.manualLogin('12345');
            expect(userService.isLoggedIn()).toEqual(true);
            expect(userService.getUserId()).toEqual('12345');
        })
    );



});
