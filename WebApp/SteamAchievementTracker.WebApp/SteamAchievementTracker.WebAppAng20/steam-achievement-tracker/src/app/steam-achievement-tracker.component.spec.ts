import {
  beforeEachProviders,
  describe,
  expect,
  it,
  inject
} from '@angular/core/testing';
import { SteamAchievementTrackerAppComponent } from '../app/steam-achievement-tracker.component';

beforeEachProviders(() => [SteamAchievementTrackerAppComponent]);

describe('App: SteamAchievementTracker', () => {
  it('should create the app',
      inject([SteamAchievementTrackerAppComponent], (app: SteamAchievementTrackerAppComponent) => {
    expect(app).toBeTruthy();
  }));

  it('should have as title \'steam-achievement-tracker works!\'',
      inject([SteamAchievementTrackerAppComponent], (app: SteamAchievementTrackerAppComponent) => {
    expect(app.title).toEqual('steam-achievement-tracker works!');
  }));
});
