import {
    beforeEachProviders,
    it,
    describe,
    expect,
    inject
} from '@angular/core/testing';
import { UserService } from './user.service';

describe('User Service', () => {
    beforeEachProviders(() => [UserService]);

    it('should ...',
        inject([UserService], (service: UserService) => {
            expect(service).toBeTruthy();
        })
    );

    it('should not be logged in',
        inject([UserService], (service: UserService) => {
            console.log(service.isLoggedIn());
            expect(service.isLoggedIn()).toEqual(false);
        })
    );

    it('should  be logged in',
        inject([UserService], (service: UserService) => {
            service.create('12345');
            expect(service.isLoggedIn()).toEqual(true);
        })
    );

    it('should  be logged in',
        inject([UserService], (service: UserService) => {
            service.create('12345');
            expect(service.isLoggedIn()).toEqual(true);
            service.destroy();
            expect(service.isLoggedIn()).toEqual(false);
        })
    );

    it('should  be persist user id',
        inject([UserService], (service: UserService) => {
            service.create('12345');
            expect(service.isLoggedIn()).toEqual(true);
            expect(service.getUserId()).toEqual('12345');
        })
    );




});
