SELECT [StatsURL] ,
	[AchievementID] ,
	[AchievementIcon] 
	[IsUnlocked] ,
	[Name] ,
	[Description] ,
	[UnLockTimestamp] 
FROM
	GameAchievement
WHERE
	[StatsURL] = @StatsURL AND
	[AchievementID]  = @AchievementID