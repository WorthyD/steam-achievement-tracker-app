Update Game set
	StatsURL = @StatsURL,
	AchievementID = @AchievementID,
	AchievementIcon = @AchievementIcon,
	IsUnlocked = @IsUnlocked,
	[Name] = @Name,
	[Description]  = @UnLockTimestamp
WHERE
	StatsURL = @StatsURL AND
	AchievementID = @AchievementID