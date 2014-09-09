using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Model
{
    public interface IPlayerLibrary
    {
        List<IGame> GameList { get; set; }
    }
}
