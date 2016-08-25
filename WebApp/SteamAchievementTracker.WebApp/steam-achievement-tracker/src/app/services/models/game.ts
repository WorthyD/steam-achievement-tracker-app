export interface IGame {
  steamId: number,
  appID: number,
  name: string,
  playtime_Forever: number,
  playtime_2weeks: number,
  img_Icon_Url: string,
  img_Logo_Url: string,
  has_community_visible_stats: boolean,
  lastUpdated: string,
  achievementRefresh: string,
  refreshAchievements: boolean,
  achievementsEarned: number,
  achievementsLocked: number,
  totalAchievements: number,
  beenProcessed: boolean,
  readyForRefresh: boolean,
  percentComplete: number,
  unlockedAchievements: any,
  lockedAchievements: any

}

/*
SteamId: 76561198025095151,
  AppID: 231740,
  name: Knights of Pen and Paper +1,
  playtime_Forever: 2264,
  playtime_2weeks: 0,
  img_Icon_Url: c8920c13bacc61396e2d6d323d0301c2005b274d,
  img_Logo_Url: 988728706a0259a446141134a2788d3892a11a0f,
  has_community_visible_stats: true,
  lastUpdated: 2016-07-08T14:19:04.037,
  achievementRefresh: 2000-01-01T00:00:00,
  refreshAchievements: false,
  achievementsEarned: 38,
  achievementsLocked: 38,
  totalAchievements: 42,
  beenProcessed: true,
  percentComplete: 0,
  gameAchievements: [

      */