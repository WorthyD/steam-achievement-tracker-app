using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Data {
    //http://www.textfixer.com/tools/remove-line-breaks.php
    public class GameAchievement : TableModelBase<Model.GameAchievement, KeyValuePair<string, string>> {
        public GameAchievement(string connection)
        {
            this.connectionString = connection;
        }


        public override string CreateTable() {
            return @"CREATE TABLE IF NOT EXISTS  [GameAchievement] (
	[StatsURL] nvARCHAR(150)  NULL,
	[AchievementID] nvARCHAR(50)  NULL,
	[AchievementIcon] nvARCHAR(200)  NULL,
	[IsUnlocked] BOOLEAN  NULL,
	[Name] nvARCHAR(100)  NULL,
	[Description] NVARCHAR(150)  NULL,
	[UnLockTimestamp] NVARCHAR(25)  NULL,
	PRIMARY KEY ([StatsURL],[AchievementID])
)";



        }

        protected override string GetSelectAllSql() {
            throw new NotImplementedException();
        }

        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement) {
            throw new NotImplementedException();
        }

        protected override Model.GameAchievement CreateItem(SQLitePCL.ISQLiteStatement statement) {
            Model.GameAchievement ga = new Model.GameAchievement() {
                AchievementIcon = statement["AchievementIcon"].ToSafeString(),
                AchievementID = statement["AchievementID"].ToSafeString(),
                Description = statement["Description"].ToSafeString(),
                IsUnlocked = statement["IsUnlocked"].ToBool(),
                Name = statement["Name"].ToSafeString(),
                StatsURL = statement["StatsURL"].ToSafeString(),
                UnlockTimestamp = statement["UnLockTimestamp"].ToSafeString()
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
	[StatsURL] = @StatsURL AND
	[AchievementID]  = @AchievementID";
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
            //SQLitePCL Express bit
            statement.Bind("@IsUnlocked",  item.IsUnlocked.BoolToBit());
            statement.Bind("@Name", item.Name);
            statement.Bind("@Description", item.Description);
            statement.Bind("@UnLockTimestamp", item.UnlockTimestamp);
        }

        protected override string GetUpdateItemSql() {
            return "Update Game set	StatsURL = @StatsURL,	AchievementID = @AchievementID,	AchievementIcon = @AchievementIcon,	IsUnlocked = @IsUnlocked,	[Name] = @Name,	[Description]  = @UnLockTimestampWHERE	StatsURL = @StatsURL AND	AchievementID = @AchievementID";
        }

        protected override Model.GameAchievement GetEmpty() {
            return null;
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


        public List<Model.GameAchievement> GetByStatsUrl(string statsUrl) {
            var items = new ObservableCollection<Model.GameAchievement>();
            string sqlStatement = "SELECT [StatsURL], [AchievementID], [AchievementIcon], [IsUnlocked], [Name], [Description], [UnLockTimestamp] FROM GameAchievement WHERE [StatsURL] = @StatsURL ";
            using (var statement = base.sqlConnection.Prepare(sqlStatement))
            {
                statement.Bind("@StatsURL", statsUrl);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    var item = CreateItem(statement);
                    items.Add(item);
                }
            }
            Timestamp = DateTime.Now;
            return items.ToList();
        }
    }
}
