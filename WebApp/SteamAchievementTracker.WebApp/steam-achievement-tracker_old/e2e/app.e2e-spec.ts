import { SteamAchievementTrackerPage } from './app.po';

describe('steam-achievement-tracker App', function() {
  let page: SteamAchievementTrackerPage;

  beforeEach(() => {
    page = new SteamAchievementTrackerPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
