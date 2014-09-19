using SQLitePCL;
using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Data
{
    public class PlayerRecentGames : TableModelBase<IRecentGame, long>
    {


        public override string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS  [PlayerRecentGames] (	[ID64] INTEGER  NOT NULL ,	[GameLink] vARCHAR(150) NOT NULL)";
        }

        protected override IRecentGame CreateItem(SQLitePCL.ISQLiteStatement statement)
        {
            IRecentGame game = new RecentGame();

            game.GameLink = statement["GameLink"].ToSafeString();
            game.ID64 = statement["ID64"].ToLong();

            return game;
        }


        protected override string GetInsertItemSql()
        {
            return "INSERT INTO PlayerRecentGames (ID64, GameLink) VALUES  ( @ID64, @GameLink );";
        }

        protected override void FillInsertStatement(SQLitePCL.ISQLiteStatement statement, IRecentGame item)
        {
            statement.Bind("@ID64", item.ID64);
            statement.Bind("@GameLink", item.GameLink);
        }

        protected override IRecentGame GetEmpty()
        {
            return null;
        }

        protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, long key)
        {
            statement.Bind("@id64", key);
        }

        protected override string GetDeleteItemSql()
        {
            return "DELETE FROM PlayerRecentGames WHERE ID64 = @id64 ;";
        }

        public List<IRecentGame> GetByUserID(long key)
        {
            var items = new ObservableCollection<IRecentGame>();
            string sqlStatement = "SELECT ID64, GameLink FROM PlayerRecentGames	WHERE ID64 = @ID64;";
            using (var statement = base.sqlConnection.Prepare(sqlStatement))
            {
                statement.Bind("@ID64", key);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    var item = CreateItem(statement);
                    items.Add(item);
                }
            }
            Timestamp = DateTime.Now;
            return items.ToList();
        }

        public void InsertAllForUser(long key, List<string> gameURLS)
        {
            this.DeleteItem(key);
            foreach (var s in gameURLS)
            {
                this.InsertItem(new RecentGame() { GameLink = s, ID64 = key });
            }
        }

        /// <summary>
        /// /////////////////////////////////Not implemented
        /// </summary>
        /// <returns></returns>
        /// 
        protected override string GetUpdateItemSql()
        {
            throw new NotImplementedException();
        }


        protected override string GetSelectItemSql()
        {
            throw new NotImplementedException();
        }

        protected override void FillSelectItemStatement(SQLitePCL.ISQLiteStatement statement, long key)
        {
            throw new NotImplementedException();
        }


        protected override string GetSelectAllSql()
        {
            throw new NotImplementedException();
        }
        protected override void FillUpdateStatement(SQLitePCL.ISQLiteStatement statement, long key, IRecentGame item)
        {
            throw new NotImplementedException();
        }



        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement)
        {
            throw new NotImplementedException();
        }



    }
}
