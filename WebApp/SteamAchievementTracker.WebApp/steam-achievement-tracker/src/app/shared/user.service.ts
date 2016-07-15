import { Injectable } from '@angular/core';

@Injectable()
export class UserService {

    constructor() {
        console.log('constructing');
    }

    private userId: string = "";

    create(userId: string) {
        this.userId = userId;
    }

    destroy() {
        this.userId = '';
    }

    isLoggedIn() : boolean {
        return  this.userId !== '';
    }

     getUserId() : string {
        return  this.userId;
    }

  

}
