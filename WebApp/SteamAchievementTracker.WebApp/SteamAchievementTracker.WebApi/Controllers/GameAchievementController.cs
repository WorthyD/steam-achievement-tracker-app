using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SteamAchievementTracker.WebApi.Controllers
{
    public class GameAchievementController : ApiController
    {
        public BLL.Providers.GameAchievementProvider GameAchievementProvider { get; set; }
        public BLL.Providers.PlayerGamceAchievementProvider PlayerGamceAchievementProvider { get; set; }

        public GameAchievementController()
        {
            GameAchievementProvider = new BLL.Providers.GameAchievementProvider();
            PlayerGamceAchievementProvider = new BLL.Providers.PlayerGamceAchievementProvider();
        }

        public async Task<ViewModels.GameDetails> Get(long id, long steamId)
        {
            try
            {

            var gameAch = GameAchievementProvider.GetGameAchievements(id);
            var playerAch = PlayerGamceAchievementProvider.GetAppAchievementsForPlayer(steamId, id);

            await Task.WhenAll(gameAch, playerAch);
            var gameAchResult = await gameAch;
            var playerAchResult = await playerAch;


            return new ViewModels.GameDetails(playerAchResult, gameAchResult.GameAchievements.ToList(), playerAchResult.PlayerGameAchievements.ToList());

            }
            catch (Exception e)
            {

                throw;
            }




        }
    }
}
