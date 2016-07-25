/* tslint:disable:no-unused-variable */

import {
  beforeEach, beforeEachProviders,
  describe, xdescribe,
  expect, it, xit,
  async, inject
} from '@angular/core/testing';
import { PlayerLibraryService } from './player-library.service';
import { BaseServiceService  } from './base-service.service';
import {UserService} from '../shared/user.service';
import { MockBackend } from '@angular/http/testing';

import { Library } from './mock-data/library.mock-data';



import {provide} from '@angular/core';
import {Http, Response, BaseRequestOptions, ResponseOptions} from '@angular/http';

describe('PlayerLibrary Service', () => {
  let user;
  let service;
  let mockBackend;

  beforeEachProviders(() => [PlayerLibraryService, BaseServiceService, UserService, MockBackend, BaseRequestOptions,
    provide(Http, {
      useFactory: (backend, options) => new Http(backend, options),
      deps: [MockBackend, BaseRequestOptions]
    })]);

  beforeEachProviders(() => [BaseServiceService, PlayerLibraryService, UserService]);

  beforeEach(inject([UserService, PlayerLibraryService, BaseServiceService, MockBackend], (s, pls, bss, mck) => {
    user = s;
    user.create('user');
    service = pls;
    mockBackend = mck;

    mockBackend.connections.subscribe(connection => {
      let body = JSON.stringify({ library: Library });
      let resp = new Response(new ResponseOptions({
        body: body
      }));
      connection.mockRespond(resp);
    });


  }));




  it('should be created',
    inject([], () => {
      expect(service).toBeTruthy();
    }));

  it('should get your library', done => {
    service.getLibrary().subscribe(x => {
      //check stuff  
      expect(x).toBeTruthy();
      expect(x.length).toEqual(4);
      done();
    });
  });

  it('should get and filter library your library', done => {
    let appIds: number[] = [261640, 263820];
    service.getLibrary().subscribe(y => {
      service.getGamesByIds(appIds).subscribe(x => {
        //check stuff  

        expect(x).toBeTruthy();
        expect(x.length).toEqual(2);
        done();
      });
    });
  });


  it('should filter your library', done => {

    let appIds: number[] = [261640, 263820];

    service.getGamesByIds(appIds).subscribe(x => {
      expect(x).toBeTruthy();
      expect(x.length).toEqual(2);
      done();
    });
  });

});
