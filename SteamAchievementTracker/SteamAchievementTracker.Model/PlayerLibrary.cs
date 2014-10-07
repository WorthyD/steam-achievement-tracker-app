using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Model
{
    public class PlayerLibrary : IPlayerLibrary
    {
        public List<IGame> GameList { get; set; }
        public List<IGame> MostPlayedGames { get; set; }
        public List<IGame> NearCompletion { get; set; }
    }
}
