UPDATE Game
SET AchievementCount = @AchievementCount,
    AchievementsEarned = @AchievementsEarned,
    AchievementRefresh = @AchievementRefresh
WHERE StatsLink = @StatsLink