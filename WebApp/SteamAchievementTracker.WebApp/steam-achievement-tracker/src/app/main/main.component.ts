import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { AuthServiceService } from '../shared/auth-service.service'
import { DashboardComponent } from '../dashboard/dashboard.component';
import { LoginComponent } from '../login/login.component';
@Component({
    moduleId: module.id,
    selector: 'app-main',
    templateUrl: 'main.component.html',
    directives: [ ROUTER_DIRECTIVES],
    //  styleUrls: ['main.component.css']
})
export class MainComponent implements OnInit {

    constructor() { }

    ngOnInit() {
    }

}
