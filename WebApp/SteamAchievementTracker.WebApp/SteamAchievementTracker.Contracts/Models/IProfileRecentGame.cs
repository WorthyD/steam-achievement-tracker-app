using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Models {
    public interface IProfileRecentGame {

        long ID64 { get; set; }
        int AppID { get; set; }
    }
}
