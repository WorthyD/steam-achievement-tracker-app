import { Component, OnInit } from '@angular/core';

import {UserService} from '../shared/user.service';
import {PlayerProfileService} from '../services/player-profile.service';
import{IPlayerProfile} from '../services/models/player-profile';

@Component({
    moduleId: module.id,
    selector: 'app-profile',
    providers:[PlayerProfileService],
    templateUrl: 'profile.component.html',
    //styleUrls: ['profile.component.css']
})
export class ProfileComponent implements OnInit {
    profile: IPlayerProfile;

    constructor(private userService: UserService, private playerService: PlayerProfileService) { }

    getProfile(){
        //this.playerService.getProfile(this.userService.getUserId()0).subscribe(profile:IPlayerProfile => this.profile = profile);
        this.playerService.getProfile(this.userService.getUserId()).then(profile => this.profile = profile).then(function(){console.log('got profile');});
    }

    ngOnInit() {
        console.log('user initing');
        console.log(this.userService.getUserId());
        this.getProfile();
        
    }

}
