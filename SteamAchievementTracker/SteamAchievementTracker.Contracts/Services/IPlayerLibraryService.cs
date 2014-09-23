using SteamAchievementTracker.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Contracts.Services
{
    public interface IPlayerLibraryService
    {
        List<IGame> GetPlayerRecentlyPlayedGames(long steamID64, List<string> gameLinks);
        Task<List<IGame>> GetPlayerLibraryCached(long steamID64);
        Task<List<IGame>> GetPlayerLibraryRefresh(long steamID64, string steamID);
        void UpdateGameStats(string statsUrl, int achievementsEarned, int totalAchievements);
        IGame GetGameByID(long appID, long userId);
    }
}
