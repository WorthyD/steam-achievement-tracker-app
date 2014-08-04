using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Data {
    public class Game : TableModelBase<Model.Game, KeyValuePair<long, long>> {
        protected override string CreateTable() {
            return @"CREATE TABLE [Game] (
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
                [PurchaseDate] TIMESTAMP  NULL,
                [LastUpdated] TIMESTAMP  NULL,
                PRIMARY KEY ([SteamID],[GameID])
            )";
        }

        protected override string GetSelectAllSql() {
            return @"Select
	                    SteamID, GameID, Name, StatsLink, GameLink, SmallLogo,
                    	HoursPlayed, AchievementsEarned, AchievementCount, PurchaseDate, LastUpdated
                    FROM
                    	Game
                    Where
                    	SteamID = @SteamID AND
    	                GameID = @GameID";
        }

        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement) {
            //statement.Bind("@SteamID", 
        }

        protected override Model.Game CreateItem(SQLitePCL.ISQLiteStatement statement) {
            var g = new Model.Game() {
                AchievementsEarned = (int)statement["AchievementsEarned"],
                AppID = (uint)statement["GameID"],
                GameLink = (string)statement["GameLink"],
                HoursOnRecord = (decimal)statement["RecentHours"],
                HoursPlayed = (decimal)statement["HoursPlayed"],
                Logo = (string)statement["SmallLogo"],
                Name = (string)statement["Name"],
                StatsLink = (string)statement["StatsLink"],
                TotalAchievements = (int)statement["AchievementCount"],
                LastUpdated = (DateTime)statement["LastUpdated"],
                PurchaseDate = (DateTime)statement["PurchaseDate"]
            };
            return g;
        }

        protected override string GetSelectItemSql() {
            return @"Select
	                    SteamID, GameID, Name, StatsLink, GameLink, SmallLogo,RecentHours,
                    	HoursPlayed, AchievementsEarned, AchievementCount, PurchaseDate, LastUpdated
                    FROM
                    	Game
                    Where
                    	SteamID = @SteamID AND
    	                GameID = @GameID";
        }

        protected override void FillSelectItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key) {
            statement.Bind("@SteamID", key.Key);
            statement.Bind("@GameID", key.Value);
        }

        protected override string GetDeleteItemSql() {
            throw new NotImplementedException();
        }

        protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, ulong key) {
            throw new NotImplementedException();
        }

        protected override string GetInsertItemSql() {
            return @"INSERT INTO Game
				(SteamID, GameID,
				Name, StatsLink,
				GameLink, SmallLogo,RecentHours,
				HoursPlayed, AchievementsEarned,
				AchievementCount, PurchaseDate,
				LastUpdated)
			VALUES
				(@SteamID, @GameID,
				@Name, @StatsLink,
				@GameLink, @SmallLogo, @RecentHours,
				@HoursPlayed, @AchievementsEarned,
				@AchievementCount, @PurchaseDate,
				@LastUpdated);";
        }

        protected override void FillInsertStatement(SQLitePCL.ISQLiteStatement statement, Model.Game item) {
            //statement.Bind("@SteamID", item.);
            statement.Bind("@GameID", item.AppID);
            statement.Bind("@Name", item.Name);
            statement.Bind("@StatsLink", item.StatsLink);
            statement.Bind("@GameLink", item.GameLink);
            statement.Bind("", item);
            statement.Bind("", item);
            statement.Bind("", item);
            statement.Bind("", item);
            statement.Bind("", item);
            statement.Bind("", item);
        }

        protected override string GetUpdateItemSql() {
            throw new NotImplementedException();
        }

        protected override void FillUpdateStatement(SQLitePCL.ISQLiteStatement statement, ulong key, Model.Game item) {
            throw new NotImplementedException();
        }

        protected override Model.Game GetEmpty() {
            throw new NotImplementedException();
        }
    }
}
