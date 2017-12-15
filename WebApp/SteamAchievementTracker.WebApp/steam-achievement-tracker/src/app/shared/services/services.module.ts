import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BaseServiceService, GameDetailsService, PlayerLibraryService, PlayerProfileService, RecentGameService } from './';


@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    BaseServiceService, GameDetailsService, PlayerLibraryService, PlayerProfileService, RecentGameService
  ],
  exports: [
    BaseServiceService, GameDetailsService, PlayerLibraryService, PlayerProfileService, RecentGameService
  ]
})
export class ServicesModule { }
