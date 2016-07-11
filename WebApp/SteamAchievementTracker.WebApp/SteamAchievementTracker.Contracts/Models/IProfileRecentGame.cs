using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Models {
    public interface IProfileRecentGame {

        long SteamId { get; set; }
        long AppId { get; set; }
    }
}
