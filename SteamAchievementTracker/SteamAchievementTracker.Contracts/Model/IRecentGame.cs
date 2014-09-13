using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Model
{
    public interface IRecentGame
    {
        long ID64 { get; set; }
        string GameLink { get; set; }
    }
}
