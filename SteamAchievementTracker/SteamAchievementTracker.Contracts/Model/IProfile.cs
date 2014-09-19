using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Model
{
    public interface IProfile
    {
        long ID64 { get; set; }
        string ID { get; set; }

        string Name { get; set; }
        string ThumbURL { get; set; }
        DateTime LastUpdate { get; set; }

        List<IGame> RecentGames { get; set; }

        List<string> RecentGameLinks { get; set; }
    }
}
