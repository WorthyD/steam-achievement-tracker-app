using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Model;

namespace SteamAchievementTracker.App.DataAccess.Data
{
    public class Game : TableModelBase<IGame, KeyValuePair<long, long>>
    {
        public Game(string connection)
        {
            this.connectionString = connection;
        }

        private string selectAllColumns
        {
            get
            {
                return @"[SteamID], [GameID], [Name], [StatsLink], [GameLink], [SmallLogo], [RecentHours],
                    	 [HoursPlayed], [RefreshAchievements], [AchievementsEarned], 
                         [AchievementCount], [AchievementRefresh], [LastUpdated]";
            }
        }
        public override string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS [Game] (
                [SteamID] BIGINT  NOT NULL,
                [GameID] INTEGER  NOT NULL,
                [Name] varCHAR(100)  NULL,
                [StatsLink] vARCHAR(150)  NULL,
                [GameLink] vARCHAR(150)  NULL,
                [SmallLogo] vARCHAR(150)  NULL,
                [LargeLogo] vARCHAR(150)  NULL,
                [HoursPlayed] FLOAT  NULL,
                [RecentHours] FLOAT  NULL,
                [RefreshAchievements] BOOLEAN  NULL,
                [AchievementsEarned] INTEGER  NULL,
                [AchievementCount] INTEGER  NULL,
                [AchievementRefresh] TIMESTAMP  NULL,
                [LastUpdated] TIMESTAMP  NULL,
                PRIMARY KEY ([SteamID],[GameID])
            )";
        }

        protected override string GetSelectAllSql()
        {
            return @"Select
	                    [SteamID], [GameID], [Name], [StatsLink], [GameLink], [SmallLogo], [RecentHours],
                    	[HoursPlayed], [RefreshAchievements], [AchievementsEarned], [AchievementCount], [AchievementRefresh], [LastUpdated]
                    FROM
                    	Game";
            //Where
            //    SteamID = @SteamID AND
            //    GameID = @GameID";
        }

        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement)
        {
            //statement.Bind("@SteamID", 
        }

        protected override IGame CreateItem(SQLitePCL.ISQLiteStatement statement)
        {
            IGame g = new Model.Game();


            g.AchievementsEarned = statement["AchievementsEarned"].ToInt();

            g.SteamUserID = statement["SteamID"].ToLong();
            g.AppID = statement["GameID"].ToInt();

            g.GameLink = statement["GameLink"].ToSafeString();
            g.RecentHours = statement["RecentHours"].ToDecimal();
            g.HoursPlayed = statement["HoursPlayed"].ToDecimal();
            g.Logo = statement["SmallLogo"].ToSafeString();
            g.StatsLink = statement["StatsLink"].ToSafeString();
            g.TotalAchievements = statement["AchievementCount"].ToInt();
            g.RefreshAchievements = statement["RefreshAchievements"].ToBool();
            g.LastUpdated = statement["LastUpdated"].ToDate();
            g.AchievementRefresh = statement["AchievementRefresh"].ToDate();
            g.Name = statement["Name"].ToSafeString();
            return g;
            //return null;
        }

        protected override string GetSelectItemSql()
        {
            return @"Select
	                    SteamID, GameID, Name, StatsLink, GameLink, SmallLogo,RecentHours,
                    	HoursPlayed, AchievementsEarned,  RefreshAchievements, AchievementCount, AchievementRefresh, LastUpdated
                    FROM
                    	Game
                    Where
                    	SteamID = @SteamID AND
    	                GameID = @GameID";
        }

        protected override void FillSelectItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key)
        {
            statement.Bind("@SteamID", key.Key);
            statement.Bind("@GameID", key.Value);
        }

        protected override string GetDeleteItemSql()
        {
            throw new NotImplementedException();
        }

        protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertItemSql()
        {
            return @"INSERT INTO Game
				(SteamID, GameID,
				Name, StatsLink,
				GameLink, SmallLogo,RecentHours,
				HoursPlayed, AchievementsEarned,
                RefreshAchievements,
				AchievementCount, AchievementRefresh,
				LastUpdated)
			VALUES
				(@SteamID, @GameID,
				@Name, @StatsLink,
				@GameLink, @SmallLogo, @RecentHours,
				@HoursPlayed, @AchievementsEarned,
                @RefreshAchievements,
				@AchievementCount, @AchievementRefresh,
				@LastUpdated);";
        }

        protected override void FillInsertStatement(SQLitePCL.ISQLiteStatement statement, IGame item)
        {
            statement.Bind("@SteamID", item.SteamUserID);
            statement.Bind("@GameID", item.AppID);
            statement.Bind("@Name", item.Name);
            statement.Bind("@StatsLink", item.StatsLink);
            statement.Bind("@GameLink", item.GameLink);
            statement.Bind("@SmallLogo", item.Logo);
            statement.Bind("@RecentHours", item.RecentHours);
            statement.Bind("@HoursPlayed", item.HoursPlayed);
            statement.Bind("@RefreshAchievements", true.BoolToBit());
            statement.Bind("@AchievementsEarned", item.AchievementsEarned);
            statement.Bind("@AchievementCount", item.TotalAchievements);
            statement.Bind("@AchievementRefresh", item.AchievementRefresh.DateTimeSQLite());
            statement.Bind("@LastUpdated", item.LastUpdated.DateTimeSQLite());
        }


        protected override string GetUpdateItemSql()
        {
            return @"Update Game
	            set Name = @Name,
            	StatsLink = @StatsLink,
            	GameLink = @GameLink,
            	SmallLogo = @SmallLogo,
                RefreshAchievements = @RefreshAchievements,
                RecentHours = @RecentHours,
            	HoursPlayed = @HoursPlayed,
            	LastUpdated =@LastUpdated
            Where
            	SteamID = @SteamID AND
            	GameID = @GameID";
        }

        protected override void FillUpdateStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key, IGame item)
        {
            statement.Bind("@GameID", item.AppID);
            statement.Bind("@Name", item.Name);
            statement.Bind("@StatsLink", item.StatsLink);
            statement.Bind("@GameLink", item.GameLink);
            statement.Bind("@SmallLogo", item.Logo);
            statement.Bind("@RecentHours", item.RecentHours);
            statement.Bind("@HoursPlayed", item.HoursPlayed);
            statement.Bind("@RefreshAchievements", item.RefreshAchievements.BoolToBit());
            //statement.Bind("@AchievementsEarned", item.AchievementsEarned);
            //statement.Bind("@AchievementCount", item.TotalAchievements);
            //statement.Bind("@PurchaseDate", item.PurchaseDate);
            statement.Bind("@LastUpdated", item.LastUpdated.DateTimeSQLite());
        }

        protected override IGame GetEmpty()
        {
            return null;
        }

        public void UpdateGameStats(string statsUrl, int achievementsEarned, int totalAchievements)
        {
            string sqlStatement = @"UPDATE Game SET 
                    AchievementCount = @AchievementCount, 
                    AchievementsEarned = @AchievementsEarned, 
                    RefreshAchievements = @RefreshAchievements,
                    AchievementRefresh = @AchievementRefresh 
                    WHERE StatsLink = @StatsLink";
            using (var statement = base.sqlConnection.Prepare(sqlStatement))
            {
                statement.Bind("@StatsLink", statsUrl);
                statement.Bind("@RefreshAchievements", false.BoolToBit());
                statement.Bind("@AchievementsEarned", achievementsEarned);
                statement.Bind("@AchievementCount", totalAchievements);
                statement.Bind("@AchievementRefresh", DateTime.Now.DateTimeSQLite());
                statement.Step();
            }
            Timestamp = DateTime.Now;
        }

        public List<IGame> GetGamesBySteamID(long id64)
        {
            var items = new ObservableCollection<IGame>();
            string sqlStatement = "Select [SteamID], [GameID], [Name], [StatsLink], [GameLink], [SmallLogo], [RecentHours], [RefreshAchievements], [HoursPlayed], [AchievementsEarned], [AchievementCount], [AchievementRefresh], [LastUpdated] FROM Game Where SteamID = @SteamID";
            using (var statement = base.sqlConnection.Prepare(sqlStatement))
            {
                statement.Bind("@SteamID", id64);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    var item = CreateItem(statement);
                    items.Add(item);
                }
            }
            Timestamp = DateTime.Now;
            return items.ToList();
        }
        public IGame GetGameBySteamIDAndUrl(long id64, string gameURL)
        {
            string sqlStatement = "Select [SteamID], [GameID], [Name], [StatsLink], [GameLink], [SmallLogo], [RecentHours],[RefreshAchievements], [HoursPlayed], [AchievementsEarned], [AchievementCount], [AchievementRefresh], [LastUpdated] FROM Game Where SteamID = @SteamID and GameLink = @GameLink";
            using (var statement = base.sqlConnection.Prepare(sqlStatement))
            {
                statement.Bind("@SteamID", id64);
                statement.Bind("@GameLink", gameURL);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    var item = CreateItem(statement);
                    return item;
                }
            }
            return GetEmpty();
        }
        //protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key) {
        //    throw new NotImplementedException();
        //}
    }
}
