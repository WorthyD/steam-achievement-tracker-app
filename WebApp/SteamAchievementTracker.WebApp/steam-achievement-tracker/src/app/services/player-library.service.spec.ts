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


  beforeEach(inject([UserService, PlayerLibraryService, MockBackend], (s, pls, mck) => {
    user = s;
    user.create('user');
    service = pls;
    mockBackend = mck;
  }));




  it('should be created',
    inject([PlayerLibraryService], (service: PlayerLibraryService) => {
      expect(service).toBeTruthy();
    }));


  it('should get your library', done => {
    let response = ["ru", "es"];
    mockBackend.connections.subscribe(connection => {
      //connection.mockRespond(new Response({ body: JSON.stringify(response) }));
      let test = '';
      connection.mockRespond(new Response( new ResponseOptions({
              body: [
                {
                  id: 26,
                  contentRendered: "<p><b>Hi there</b></p>",
                  contentMarkdown: "*Hi there*"
                }]
            }
          )));
    });

    service.getLibrary().subscribe(x => {
      //check stuff  

      done();

    });

  });







});
