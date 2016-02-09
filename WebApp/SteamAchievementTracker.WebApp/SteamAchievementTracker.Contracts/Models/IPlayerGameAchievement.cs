using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Models
{
    public interface IPlayerGameAchievement
    {
        long SteamId { get; set; }
        long AppID { get; set; }
        string ApiName { get; set; }
        bool Achieved { get; set; }
        DateTime UnlockTimestamp { get; set; }


    }
}
