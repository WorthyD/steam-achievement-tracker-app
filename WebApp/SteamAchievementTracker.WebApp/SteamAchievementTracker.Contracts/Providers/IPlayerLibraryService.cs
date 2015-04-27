using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Providers {
    public interface IPlayerLibraryService {
        List<IPlayerGame> GetPlayerRecentlyPlayedGames(long steamID64, List<string> gameLinks);
        Task<List<IPlayerGame>> GetPlayerLibraryCached(long steamID64);
        Task<List<IPlayerGame>> GetPlayerLibraryRefresh(long steamID64, string steamID);
        void UpdateGameStats(string statsUrl, string gameIcon, int achievementsEarned, int totalAchievements);
        IPlayerGame GetGameByID(long appID, long userId);
        IPlayerGameAchievement GetPlayerStats(long steamID64);
    }
}
