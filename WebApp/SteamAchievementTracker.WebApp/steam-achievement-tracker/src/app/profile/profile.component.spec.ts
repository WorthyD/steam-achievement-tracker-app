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
import { ProfileComponent } from './profile.component';

import { BaseServiceService  } from '../services/base-service.service';
import { PlayerProfileService } from '../services/player-profile.service';

import {UserService} from '../shared/user.service';

describe('Component: Profile', () => {
  let builder: TestComponentBuilder;

  beforeEachProviders(() => [ProfileComponent, UserService, BaseServiceService, PlayerProfileService]);
  beforeEach(inject([TestComponentBuilder], function (tcb: TestComponentBuilder) {
    builder = tcb;
  }));

  it('should inject the component', inject([ProfileComponent],
    (component: ProfileComponent) => {
      expect(component).toBeTruthy();
    }));

  it('should create the component', inject([], () => {
    return builder.createAsync(ProfileComponentTestController)
      .then((fixture: ComponentFixture<any>) => {
        let query = fixture.debugElement.query(By.directive(ProfileComponent));
        expect(query).toBeTruthy();
        expect(query.componentInstance).toBeTruthy();
      });
  }));
});

@Component({
  selector: 'test',
  template: `
    <app-profile></app-profile>
  `,
  directives: [ProfileComponent]
})
class ProfileComponentTestController {
}

