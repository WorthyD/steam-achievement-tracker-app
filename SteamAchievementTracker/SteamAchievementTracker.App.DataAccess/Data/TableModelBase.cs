using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Data {
    public abstract class TableModelBase<TItemType, TKeyType> {

        public virtual string connectionString { get; set; }

        public abstract string CreateTable();

        protected abstract string GetSelectAllSql();
        protected abstract void FillSelectAllStatement(ISQLiteStatement statement);

        protected abstract TItemType CreateItem(ISQLiteStatement statement);

        protected abstract string GetSelectItemSql();
        protected abstract void FillSelectItemStatement(ISQLiteStatement statement, TKeyType key);

        protected abstract string GetDeleteItemSql();
        protected abstract void FillDeleteItemStatement(ISQLiteStatement statement, TKeyType key);

        protected abstract string GetInsertItemSql();
        protected abstract void FillInsertStatement(ISQLiteStatement statement, TItemType item);

        protected abstract string GetUpdateItemSql();
        protected abstract void FillUpdateStatement(ISQLiteStatement statement, TKeyType key, TItemType item);

        protected abstract TItemType GetEmpty();

        protected DateTime lastModifiedTime = DateTime.MaxValue;
        public virtual DateTime Timestamp {
            get { return lastModifiedTime; }
            protected set { lastModifiedTime = value; }
        }

        public static SQLiteConnection conn;

        public ISQLiteConnection sqlConnection {
            get {
                if (conn == null) {
                    conn = new SQLiteConnection(connectionString);
                    //conn = new SQLiteConnection("c:\\dev\\SteamAchievementTracker.db");
                    CreateDatabase.LoadDatabase(conn);
                    //SQLitePCL.
                }
                return conn;
            }
        }


        public ObservableCollection<TItemType> GetAllItems() {
            var items = new ObservableCollection<TItemType>();
            using (var statement = sqlConnection.Prepare(GetSelectAllSql())) {
                FillSelectAllStatement(statement);
                while (statement.Step() == SQLiteResult.ROW) {
                    var item = CreateItem(statement);
                    items.Add(item);
                }
            }
            Timestamp = DateTime.Now;

            return items;
        }

        public TItemType GetItem(TKeyType key) {
            using (var statement = sqlConnection.Prepare(GetSelectItemSql())) {
                FillSelectItemStatement(statement, key);

                if (statement.Step() == SQLiteResult.ROW) {
                    var item = CreateItem(statement);
                    Timestamp = DateTime.Now;
                    return item;
                }
            }

            return GetEmpty();
        }

        public void InsertItem(TItemType item) {
            using (var statement = sqlConnection.Prepare(GetInsertItemSql())) {
                FillInsertStatement(statement, item);
                statement.Step();
            }
            Timestamp = DateTime.Now;
        }

        public void UpdateItem(TKeyType key, TItemType item) {
            using (var statement = sqlConnection.Prepare(GetUpdateItemSql())) {
                FillUpdateStatement(statement, key, item);
                statement.Step();
            }
            Timestamp = DateTime.Now;
        }

        public void DeleteItem(TKeyType key) {
            using (var statement = sqlConnection.Prepare(GetDeleteItemSql())) {
                FillDeleteItemStatement(statement, key);
                statement.Step();
            }
            Timestamp = DateTime.Now;
        }


    }
    public static class ExtMethods
    {
        public static int BoolToBit(this bool value)
        {
            return (value) ? 1 : 0;
        }
        public static string DateTimeSQLite(this DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }
    }
}
