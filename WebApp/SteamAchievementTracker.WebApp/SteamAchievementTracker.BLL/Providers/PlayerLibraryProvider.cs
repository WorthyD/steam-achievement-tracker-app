using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Providers
{
    public class PlayerLibraryProvider : BaseProvider
    {
        public async Task<List<Contracts.Models.IPlayerGame>> GetPlayerLibrary(long steamId)
        {
            List<DataAccess.Models.PlayerGame> games = new List<DataAccess.Models.PlayerGame>();
            using (var db = new DataAccess.ModelContext())
            {
                games = db.PlayerGames.Where(x => x.SteamId == steamId).ToList();
            }

            return games.ToList<IPlayerGame>();
        }
    }
}
