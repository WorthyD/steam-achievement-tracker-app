using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Data {
    public class Game : TableModelBase<Model.Game, KeyValuePair<ulong, ulong>> {
        public override string CreateTable() {
            return @"CREATE TABLE IF NOT EXISTS [Game] (
                [SteamID] INTEGER  NOT NULL,
                [GameID] INTEGER  NOT NULL,
                [Name] varCHAR(100)  NULL,
                [StatsLink] vARCHAR(500)  NULL,
                [GameLink] vARCHAR(500)  NULL,
                [SmallLogo] vARCHAR(500)  NULL,
                [LargeLogo] vARCHAR(500)  NULL,
                [HoursPlayed] FLOAT  NULL,
                [RecentHours] FLOAT  NULL,
                [AchievementsEarned] INTEGER  NULL,
                [AchievementCount] INTEGER  NULL,
                [AchievementRefresh] TIMESTAMP  NULL,
                [LastUpdated] TIMESTAMP  NULL,
                PRIMARY KEY ([SteamID],[GameID])
            )";
        }

        protected override string GetSelectAllSql() {
            return @"Select
	                    SteamID, GameID, Name, StatsLink, GameLink, SmallLogo,
                    	HoursPlayed, AchievementsEarned, AchievementCount, AchievementRefresh, LastUpdated
                    FROM
                    	Game";
                    //Where
                    //    SteamID = @SteamID AND
                    //    GameID = @GameID";
        }

        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement) {
            //statement.Bind("@SteamID", 
        }

        protected override Model.Game CreateItem(SQLitePCL.ISQLiteStatement statement) {
            var g = new Model.Game() {
                AchievementsEarned = (int)statement["AchievementsEarned"],
                SteamUserID =  (ulong)statement["SteamID"],
                AppID = (uint)statement["GameID"],
                GameLink = (string)statement["GameLink"],
                RecentHours = (decimal)statement["RecentHours"],
                HoursPlayed = (decimal)statement["HoursPlayed"],
                Logo = (string)statement["SmallLogo"],
                Name = (string)statement["Name"],
                StatsLink = (string)statement["StatsLink"],
                TotalAchievements = (int)statement["AchievementCount"],
                LastUpdated = (DateTime)statement["LastUpdated"],
                AchievementRefresh = (DateTime)statement["AchievementRefresh"]
            };
            return g;
        }

        protected override string GetSelectItemSql() {
            return @"Select
	                    SteamID, GameID, Name, StatsLink, GameLink, SmallLogo,RecentHours,
                    	HoursPlayed, AchievementsEarned, AchievementCount, AchievementRefresh, LastUpdated
                    FROM
                    	Game
                    Where
                    	SteamID = @SteamID AND
    	                GameID = @GameID";
        }

        protected override void FillSelectItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<ulong, ulong> key) {
            statement.Bind("@SteamID", key.Key);
            statement.Bind("@GameID", key.Value);
        }

        protected override string GetDeleteItemSql() {
            throw new NotImplementedException();
        }

        protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<ulong, ulong> key) {
            throw new NotImplementedException();
        }

        protected override string GetInsertItemSql() {
            return @"INSERT INTO Game
				(SteamID, GameID,
				Name, StatsLink,
				GameLink, SmallLogo,RecentHours,
				HoursPlayed, AchievementsEarned,
				AchievementCount, AchievementRefresh,
				LastUpdated)
			VALUES
				(@SteamID, @GameID,
				@Name, @StatsLink,
				@GameLink, @SmallLogo, @RecentHours,
				@HoursPlayed, @AchievementsEarned,
				@AchievementCount, @AchievementRefresh,
				@LastUpdated);";
        }

        protected override void FillInsertStatement(SQLitePCL.ISQLiteStatement statement, Model.Game item) {
            statement.Bind("@SteamID", item.SteamUserID);
            statement.Bind("@GameID", item.AppID);
            statement.Bind("@Name", item.Name);
            statement.Bind("@StatsLink", item.StatsLink);
            statement.Bind("@GameLink", item.GameLink);
            statement.Bind("@SmallLogo", item.Logo);
            statement.Bind("@RecentHours", item.RecentHours);
            statement.Bind("@HoursPlayed", item.HoursPlayed);
            statement.Bind("@AchievementsEarned", item.AchievementsEarned);
            statement.Bind("@AchievementCount", item.TotalAchievements);
            statement.Bind("@AchievementRefresh", DateTimeSQLite(item.AchievementRefresh));
            statement.Bind("@LastUpdated", DateTimeSQLite(item.LastUpdated));
        }
        private string DateTimeSQLite(DateTime datetime) {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }

        protected override string GetUpdateItemSql() {
            return @"Update Game
	            set Name = @Name,
            	StatsLink = @StatsLink,
            	GameLink = @GameLink,
            	SmallLogo = @SmallLogo,
            	HoursPlayed = @HoursPlayed,
            	LastUpdated =@LastUpdated
            Where
            	SteamID = @SteamID AND
            	GameID = @GameID";
        }

        protected override void FillUpdateStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<ulong, ulong> key, Model.Game item) {
            statement.Bind("@GameID", item.AppID);
            statement.Bind("@Name", item.Name);
            statement.Bind("@StatsLink", item.StatsLink);
            statement.Bind("@GameLink", item.GameLink);
            statement.Bind("@SmallLogo", item.Logo);
            statement.Bind("@RecentHours", item.RecentHours);
            statement.Bind("@HoursPlayed", item.HoursPlayed);
            statement.Bind("@AchievementsEarned", item.AchievementsEarned);
            statement.Bind("@AchievementCount", item.TotalAchievements);
            //statement.Bind("@PurchaseDate", item.PurchaseDate);
            statement.Bind("@LastUpdated", item.LastUpdated);
        }

        protected override Model.Game GetEmpty() {
            return null;
        }

        //protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key) {
        //    throw new NotImplementedException();
        //}
    }
}
