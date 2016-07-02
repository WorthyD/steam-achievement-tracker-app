import { Component, OnInit } from '@angular/core';

import {UserService} from '../shared/user.service';

@Component({
    moduleId: module.id,
    selector: 'app-profile',
    providers:[],
    templateUrl: 'profile.component.html',
    styleUrls: ['profile.component.css']
})
export class ProfileComponent implements OnInit {

    constructor(private userService: UserService) { }

    ngOnInit() {
        console.log('user initing');
        console.log(this.userService.getUserId());
    }

}
