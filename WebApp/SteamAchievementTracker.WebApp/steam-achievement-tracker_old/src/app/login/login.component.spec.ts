import {
  beforeEach,
  beforeEachProviders,
  describe,
  expect,
  it,
  inject,
} from '@angular/core/testing';
import { ComponentFixture, TestComponentBuilder } from '@angular/compiler/testing';
import { Component } from '@angular/core';
import { By } from '@angular/platform-browser';
import { LoginComponent } from './login.component';
import { AuthServiceService } from '../shared/auth-service.service';
import { UserService } from '../shared/user.service';
import { HTTP_PROVIDERS } from '@angular/http';

import {  CookieService } from 'angular2-cookie/core';

describe('Component: Login', () => {
  let builder: TestComponentBuilder;

  beforeEachProviders(() => [HTTP_PROVIDERS, CookieService,AuthServiceService, LoginComponent, UserService]);
  beforeEach(inject([TestComponentBuilder], function (tcb: TestComponentBuilder) {
    builder = tcb;
  }));

  it('should inject the component', inject([LoginComponent],
      (component: LoginComponent) => {
    expect(component).toBeTruthy();
  }));

  it('should create the component', inject([], () => {
    return builder.createAsync(LoginComponentTestController)
      .then((fixture: ComponentFixture<any>) => {
        let query = fixture.debugElement.query(By.directive(LoginComponent));
        expect(query).toBeTruthy();
        expect(query.componentInstance).toBeTruthy();
      });
  }));
});

@Component({
  selector: 'test',
  template: `
    <app-login></app-login>
  `,
  directives: [LoginComponent]
})
class LoginComponentTestController {
}

