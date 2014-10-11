using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SteamAchievementTracker.App.DataAccess.Data
{
    public class PlayerProfile : TableModelBase<IProfile, long>
    {


        public PlayerProfile(string connection)
        {
            this.connectionString = connection;
        }

        protected override string GetSelectAllSql()
        {
            return "select [ID64], [ID], [Name], [Thumbnail], [LastUpdate] from PlayerProfile";
        }

        protected override void FillSelectAllStatement(SQLitePCL.ISQLiteStatement statement)
        {
            throw new NotImplementedException();
        }

        protected override IProfile CreateItem(SQLitePCL.ISQLiteStatement statement)
        {
            var p = new Model.Profile(
                (long)statement[0],
                (string)statement[1],
                (string)statement[2],
                (string)statement[3],
                statement[4].ToDate()
                );
            Debug.WriteLine(string.Format("Selecting user id: {0}", p.ID));
            return p;
        }

        protected override string GetSelectItemSql()
        {
            return "select [ID64], [ID], [Name], [Thumbnail], [LastUpdate] from PlayerProfile WHERE ID64 = ?";
        }

        protected override void FillSelectItemStatement(SQLitePCL.ISQLiteStatement statement, long key)
        {
            statement.Bind(1, key);
        }

        protected override string GetDeleteItemSql()
        {
            throw new NotImplementedException();
        }

        protected override void FillDeleteItemStatement(SQLitePCL.ISQLiteStatement statement, long key)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertItemSql()
        {
            //throw new NotImplementedException();
            return "INSERT INTO PlayerProfile ([ID64], [ID], [Name], [Thumbnail], [LastUpdate]) VALUES (@id64, @id, @name, @thumbnail, @lastupdate)";
        }

        protected override void FillInsertStatement(SQLitePCL.ISQLiteStatement statement, IProfile item)
        {
            //  throw new NotImplementedException();
            //statement.Bind("@id64", item.ID64);
            statement.Bind("@id64", item.ID64);
            statement.Bind("@id", item.ID);
            statement.Bind("@name", item.Name);
            statement.Bind("@thumbnail", item.ThumbURL);
            statement.Bind("@lastupdate", DateTime.Now.DateTimeSQLite());
        }

        protected override string GetUpdateItemSql()
        {
            return "UPDATE PlayerProfile set ID = ?, Name = ?, Thumbnail = ?, LastUpdate = ? where ID64 = ?";
        }

        protected override void FillUpdateStatement(SQLitePCL.ISQLiteStatement statement, long key, IProfile item)
        {
            //throw new NotImplementedException();
            statement.Bind(1, item.ID);
            statement.Bind(2, item.Name);
            statement.Bind(3, item.ThumbURL);
            statement.Bind(4, DateTime.Now.DateTimeSQLite());
            statement.Bind(5, key);
        }

        protected override IProfile GetEmpty()
        {
            return null;
        }

        public override string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS  [PlayerProfile] (
                    [ID64] INTEGER  NOT NULL PRIMARY KEY,
                    [ID] VARCHAR(250)  NULL,
                    [Name] VARCHAR(250)  NULL,
                    [Thumbnail] VARCHAR(250)  NULL,
                    [LastUpdate] TIMESTAMP NULL
                );";
        }

        public override string connectionString
        {
            get;
            set;
        }
    }
}
