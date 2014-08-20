Select
	[SteamID], [GameID], [Name], [StatsLink], [GameLink], [SmallLogo], [RecentHours],
	[HoursPlayed], [AchievementsEarned], [AchievementCount], [AchievementRefresh], [LastUpdated]
FROM
	Game
Where
	SteamID = @SteamID


--Select [SteamID], [GameID], [Name], [StatsLink], [GameLink], [SmallLogo], [RecentHours], [HoursPlayed], [AchievementsEarned], [AchievementCount], [AchievementRefresh], [LastUpdated] FROM Game Where SteamID = @SteamID