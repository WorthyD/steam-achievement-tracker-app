using SteamAchievementTracker.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SteamAchievementTracker.BLL.Converters.ServiceToModel;

namespace SteamAchievementTracker.BLL.Providers
{
    public class PlayerLibraryProvider : BaseProvider
    {
        public class ConvertGame : IFullGameDetails
        {
            //DataAccess.Models.PlayerGame 
            public  IPlayerGame PlayerGame { get; set; }

            public IGameSchema Schema { get; set; }
        }
        public async Task<List<Contracts.Models.IFullGameDetails>> GetPlayerLibrary(long steamId)
        {
            List<ConvertGame> games = new List<ConvertGame>();
            List<IFullGameDetails> gameDetails = new List<IFullGameDetails>();
            using (var db = new DataAccess.ModelContext())
            {
                //games = db.PlayerGames.Include(x => x.GameSchema).Where(x => x.SteamId == steamId).ToList();
//                games = db.PlayerGames.Include(x => x.GameSchema).Where(x => x.SteamId == steamId)
  //                 .ToList();
                games = db.PlayerGames.Include(x => x.GameSchema).Where(x => x.SteamId == steamId).
                    Select(x => new ConvertGame() {PlayerGame = x, Schema = x.GameSchema })
                   .ToList();


            }

            /*
            foreach (var g in games)
            {
                gameDetails.Add(
            }
            */
            return games.ToList<IFullGameDetails>();

            //            return games.ToList<IPlayerGame>();
            return gameDetails;
        }
    }
}
