CREATE TABLE[GameAchievement] (
	[StatsURL] nvARCHAR(150)  NULL,
	[AchievementID] nvARCHAR(50)  NULL,
	[AchievementIcon] nvARCHAR(150)  NULL,
	[IsUnlocked] BOOLEAN  NULL,
	[Name] nvARCHAR(150)  NULL,
	[Description] NVARCHAR(250)  NULL,
	[UnLockTimestamp] NVARCHAR(25)  NULL,
	PRIMARY KEY ([StatsURL],[AchievementID])
) --[IF] NOT EXISTS  