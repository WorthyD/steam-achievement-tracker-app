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

        #region Public Methods

        #endregion 


        private string selectAllColumns
        {
            get
            {
                return @"[SteamID], [GameID], [Name], [StatsLink], [GameLink], [LargeLogo], [GameIcon], [RecentHours],
                    	 [HoursPlayed], [RefreshAchievements], [AchievementsEarned], 
                         [AchievementCount], [HasAchievements], [AchievementRefresh], [LastUpdated]";
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
                [GameIcon] vARCHAR(150)  NULL,
                [LargeLogo] vARCHAR(150)  NULL,
                [HoursPlayed] FLOAT  NULL,
                [RecentHours] FLOAT  NULL,
                [HasAchievements] BOOLEAN  NULL,
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
            return string.Format(@"Select
	                 {0}
                    FROM
                    	Game", selectAllColumns);
        }

        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement)
        {
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
            g.Logo = statement["LargeLogo"].ToSafeString();
            g.Icon = statement["GameIcon"].ToSafeString();
            g.StatsLink = statement["StatsLink"].ToSafeString();
            g.TotalAchievements = statement["AchievementCount"].ToInt();
            g.RefreshAchievements = statement["RefreshAchievements"].ToBool();
            g.LastUpdated = statement["LastUpdated"].ToDate();
            g.AchievementRefresh = statement["AchievementRefresh"].ToDate();
            g.Name = statement["Name"].ToSafeString();

            g.HasAchievements = statement["HasAchievements"].ToBool();
            return g;
        }

        protected override string GetSelectItemSql()
        {
            return string.Format(@"Select
                        {0}
                    FROM
                    	Game
                    Where
                    	SteamID = @SteamID AND
    	                GameID = @GameID", selectAllColumns);
        }

        protected override void FillSelectItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key)
        {
            statement.Bind("@SteamID", key.Key);
            statement.Bind("@GameID", key.Value);
        }

       
        protected override string GetInsertItemSql()
        {
            return @"INSERT INTO Game
				(SteamID, 
                GameID,
				Name, 
                StatsLink, 
                LargeLogo,
				GameLink, 
                GameIcon, 
                RecentHours,
				HoursPlayed, 
                AchievementsEarned,
                RefreshAchievements, 
                HasAchievements,
				AchievementCount, 
                AchievementRefresh,
				LastUpdated)
			VALUES
				(@SteamID, 
                @GameID,
				@Name, 
                @StatsLink, 
                @LargeLogo,
				@GameLink, 
                @GameIcon, 
                @RecentHours,
				@HoursPlayed, 
                @AchievementsEarned,
                @RefreshAchievements, 
                @HasAchievements,
				@AchievementCount,
                @AchievementRefresh,
				@LastUpdated);";
        }

        protected override void FillInsertStatement(SQLitePCL.ISQLiteStatement statement, IGame item)
        {
            statement.Bind("@SteamID", item.SteamUserID);
            statement.Bind("@GameID", item.AppID);
            statement.Bind("@Name", item.Name);
            statement.Bind("@StatsLink", item.StatsLink);
            statement.Bind("@GameLink", item.GameLink);
            statement.Bind("@LargeLogo", item.Logo);
            statement.Bind("@GameIcon", item.Icon);
            statement.Bind("@RecentHours", item.RecentHours);
            statement.Bind("@HoursPlayed", item.HoursPlayed);
            statement.Bind("@HasAchievements", item.HasAchievements.BoolToBit());
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
                LargeLogo = @LargeLogo,
            	GameIcon = @GameIcon,
                RefreshAchievements = @RefreshAchievements,
                HasAchievements = @HasAchievements,
                RecentHours = @RecentHours,
            	HoursPlayed = @HoursPlayed,
            	LastUpdated = @LastUpdated
            Where
            	SteamID = @SteamID AND
            	GameID = @GameID";
        }

        protected override void FillUpdateStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key, IGame item)
        {
            statement.Bind("@GameID", key.Value);
            statement.Bind("@SteamID", key.Key);
            statement.Bind("@Name", item.Name);
            statement.Bind("@StatsLink", item.StatsLink);
            statement.Bind("@GameLink", item.GameLink);
            statement.Bind("@LargeLogo", item.Logo);
            statement.Bind("@GameIcon", item.Icon);
            statement.Bind("@RecentHours", item.RecentHours);
            statement.Bind("@HoursPlayed", item.HoursPlayed);
            statement.Bind("@RefreshAchievements", item.RefreshAchievements.BoolToBit());
            statement.Bind("@HasAchievements", item.HasAchievements.BoolToBit());
            statement.Bind("@LastUpdated", DateTime.Now.DateTimeSQLite());
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
            string sqlStatement =  string.Format("Select {0} FROM Game Where SteamID = @SteamID", selectAllColumns);
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
            string sqlStatement = string.Format("Select {0} FROM Game Where SteamID = @SteamID and GameLink = @GameLink", selectAllColumns);
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

        public IStatistics GetStats(long id64)
        {
            string sqlStatement = @" select 
	                            (select count(GameID) from game where SteamID = @SteamID) as LibraryCount,
	                            (select sum(AchievementCount ) from game  where SteamID = @SteamID) as TotalAchievements,
                                (select count(GameID) from game  where SteamID = @SteamID and AchievementCount = AchievementsEarned and AchievementCount > 0 ) as PerfectGames,
	                            (select sum(AchievementsEarned) from game  where SteamID = @SteamID) as AchievementsEarned,
	                            (select sum(HoursPlayed) from game  where SteamID = @SteamID) as HoursPlayed";

            using (var statement = base.sqlConnection.Prepare(sqlStatement))
            {
                statement.Bind("@SteamID", id64);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    IStatistics s = new Model.PlayerStats();
                    s.AchievementCount = statement["TotalAchievements"].ToInt();
                    s.LibraryCount = statement["LibraryCount"].ToInt();
                    s.TotalPlayTime = Convert.ToInt32(statement["HoursPlayed"].ToDecimal());
                    s.UnlockedAchievementCount = statement["AchievementsEarned"].ToInt();
                    s.PerfectGames = statement["PerfectGames"].ToInt();
                    return s;
                }
            }
            return null;
        }
        protected override string GetDeleteItemSql()
        {
            throw new NotImplementedException();
        }

        protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key)
        {
            throw new NotImplementedException();
        }


        //protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, KeyValuePair<long, long> key) {
        //    throw new NotImplementedException();
        //}
    }
}
