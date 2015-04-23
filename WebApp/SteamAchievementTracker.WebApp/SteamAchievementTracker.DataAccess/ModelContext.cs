using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SteamAchievementTracker.DataAccess {
    public class ModelContext :DbContext {
        public static string Connection {
            get {

                return "SteamAchievementTracker";
            }
        }
        public ModelContext() : base(Connection) { }




    }
}
