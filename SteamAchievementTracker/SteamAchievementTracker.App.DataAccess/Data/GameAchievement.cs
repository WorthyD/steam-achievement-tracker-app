using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Data {
    //http://www.textfixer.com/tools/remove-line-breaks.php
    public class GameAchievement : TableModelBase<Model.GameAchievement, KeyValuePair<string, string>> {

        public override string CreateTable() {
            throw new NotImplementedException();
        }

        protected override string GetSelectAllSql() {
            throw new NotImplementedException();
        }

        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement) {
            throw new NotImplementedException();
        }

        protected override Model.GameAchievement CreateItem(SQLitePCL.ISQLiteStatement statement) {
            Model.GameAchievement ga = new Model.GameAchievement() {
                AchievementIcon = (string)statement["AchievementIcon"],
                AchievementID = (string)statement["AchievementID"],
                Description = (string)statement["Description"],
                IsUnlocked = (bool)statement["IsUnlocked"],
                Name = (string)statement["Name"],
                StatsURL = (string)statement["StatsURL"],
                UnlockTimestamp = (string)statement["UnlockTimestamp"]
            };
            return ga;
        }

        protected override string GetSelectItemSql() {
            return @"SELECT [StatsURL] ,
	[AchievementID] ,
	[AchievementIcon] ,
	[IsUnlocked] ,
	[Name] ,
	[Description] ,
	[UnLockTimestamp] 
FROM
	GameAchievement
WHERE
	[StatsURL] = @StatsURL";
        }

        protected override string GetDeleteItemSql() {
            throw new NotImplementedException();
        }



        protected override string GetInsertItemSql() {
            return "INSERT INTO GameAchievement ([StatsURL] , [AchievementID] , [AchievementIcon], [IsUnlocked] , [Name] , [Description] , [UnLockTimestamp] ) VALUES (@StatsURL, @AchievementID, @AchievementIcon, @IsUnlocked, @Name, @Description, @UnLockTimestamp)";
        }

        protected override void FillInsertStatement(SQLitePCL.ISQLiteStatement statement, Model.GameAchievement item) {
            statement.Bind("@StatsURL", item.StatsURL);
            statement.Bind("@AchievementID", item.AchievementID);
            statement.Bind("@AchievementIcon", item.AchievementIcon);
            statement.Bind("@IsUnlocked", item.IsUnlocked);
            statement.Bind("@Name", item.Name);
            statement.Bind("@Description", item.Description);
            statement.Bind("@UnLockTimestamp", item.UnlockTimestamp);
        }

        protected override string GetUpdateItemSql() {
            return "Update Game set	StatsURL = @StatsURL,	AchievementID = @AchievementID,	AchievementIcon = @AchievementIcon,	IsUnlocked = @IsUnlocked,	[Name] = @Name,	[Description]  = @UnLockTimestampWHERE	StatsURL = @StatsURL AND	AchievementID = @AchievementID";
        }

        protected override Model.GameAchievement GetEmpty() {
            throw new NotImplementedException();
        }

        protected override void FillSelectItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<string, string> key) {
            statement.Bind("@StatsURL", key.Key);
            statement.Bind("@AchievementID", key.Value);
        }

        protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<string, string> key) {
            throw new NotImplementedException();
        }

        protected override void FillUpdateStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<string, string> key, Model.GameAchievement item) {
            statement.Bind("@StatsURL", key.Key);
            statement.Bind("@AchievementID", key.Value);
            statement.Bind("@AchievementIcon", item.AchievementIcon);
            statement.Bind("@IsUnlocked", item.IsUnlocked);
            statement.Bind("@Name", item.Name);
            statement.Bind("@Description", item.Description);
            statement.Bind("@UnLockTimestamp", item.UnlockTimestamp);
        }
    }
}
