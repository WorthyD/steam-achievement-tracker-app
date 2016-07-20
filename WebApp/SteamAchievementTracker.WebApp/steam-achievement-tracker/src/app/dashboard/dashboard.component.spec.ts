/* tslint:disable:no-unused-variable */

import { By }           from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import {
  beforeEach, beforeEachProviders,
  describe, xdescribe,
  expect, it, xit,
  async, inject
} from '@angular/core/testing';

import { DashboardComponent } from './dashboard.component';
import {RecentGamesService} from '../services/recent-games.service';

import { BaseServiceService  } from '../services/base-service.service';
import { PlayerLibraryService  } from '../services/player-library.service';

describe('Component: Dashboard', () => {
  beforeEachProviders(() => [BaseServiceService, PlayerLibraryService, RecentGamesService]);
  
  it('should create an instance', inject([RecentGamesService], (service: RecentGamesService)  => {
    let component = new DashboardComponent(service);
    expect(component).toBeTruthy();
  }));
});
