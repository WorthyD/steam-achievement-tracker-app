export class SteamAchievementTrackerPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('steam-achievement-tracker-app h1')).getText();
  }
}
