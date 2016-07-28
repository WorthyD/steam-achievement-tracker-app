/* tslint:disable:no-unused-variable */
import {
  beforeEach,
  beforeEachProviders,
  describe,
  expect,
  it
} from '@angular/core/testing';
import { By }           from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { addProviders, async, inject } from '@angular/core/testing';
import { GameListComponent } from './game-list.component';

import { Router } from '@angular/router';

describe('Component: GameList', () => {

  beforeEachProviders(() => [Router]);
  
  it('should create an instance', inject([Router], (router:Router) => {
    let component = new GameListComponent(router);
    expect(component).toBeTruthy();
  }));
});
