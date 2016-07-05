/* tslint:disable:no-unused-variable */

import {
    beforeEach, beforeEachProviders,
    describe, xdescribe,
    expect, it, xit,
    async, inject
} from '@angular/core/testing';
import { AppComponent } from './app.component';
import { AuthServiceService } from './shared/auth-service.service'
import { HTTP_PROVIDERS } from '@angular/http';
import { UserService } from './shared/user.service';
import {  CookieService } from 'angular2-cookie/core'


beforeEachProviders(() => [AppComponent, HTTP_PROVIDERS, AuthServiceService, UserService, CookieService]);

describe('App: SteamAchievementTracker', () => {
    it('should create the app',
        inject([AppComponent], (app: AppComponent) => {
            expect(app).toBeTruthy();
        }));
      
    it('should have as title \'steam-achievement-tracker works!\'',
        inject([AppComponent], (app: AppComponent) => {
            expect(app.title).toEqual('steam-achievement-tracker works!');
        }));
});
