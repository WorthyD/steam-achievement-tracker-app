CREATE TABLE[GameAchievement] (
	[StatsURL] nvARCHAR(150)  NULL,
	[AchievementID] nvARCHAR(50)  NULL,
	[AchievementIcon] nvARCHAR(200)  NULL,
	[IsUnlocked] BOOLEAN  NULL,
	[Name] nvARCHAR(100)  NULL,
	[Description] NVARCHAR(150)  NULL,
	[UnLockTimestamp] NVARCHAR(25)  NULL,
	PRIMARY KEY ([StatsURL],[AchievementID])
) --[IF] NOT EXISTS  