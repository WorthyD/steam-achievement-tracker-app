using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.BLL.Providers
{
    public class RecentGameProvider : BaseProvider
    {
        public async Task<List<IProfileRecentGame>> GetRecentlyPlayedGames(long steamId)
        {
            List<DataAccess.Models.ProfileRecentGame> games = new List<DataAccess.Models.ProfileRecentGame>();

            using (var db = new DataAccess.ModelContext())
            {
                games = db.ProfileRecentGames.Where(x => x.SteamId == steamId).ToList();
            }

            return games.ToList<IProfileRecentGame>();
        }

    }
}
