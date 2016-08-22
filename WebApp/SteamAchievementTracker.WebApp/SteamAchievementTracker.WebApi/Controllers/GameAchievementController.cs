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

        public async Task<IHttpActionResult> Get(long id, long steamId)
        {
            try
            {

                var gameAch = GameAchievementProvider.GetGameAchievements(id);
                var playerAch = PlayerGamceAchievementProvider.GetAppAchievementsForPlayer(steamId, id);
                //var gameSch = GameAchievementProvider.ge

                await Task.WhenAll(gameAch, playerAch);
                var gameAchResult = await gameAch;
                var playerAchResult = await playerAch;

                if (playerAchResult == null) {
                    return NotFound();
                }

                return Ok(new ViewModels.GameDetails(playerAchResult, gameAchResult));

/*
                var gameAch = await GameAchievementProvider.GetGameAchievements(id);
                var playerAch = await PlayerGamceAchievementProvider.GetAppAchievementsForPlayer(steamId, id);


                return new ViewModels.GameDetails(playerAch, gameAch.GameAchievements.ToList(), playerAch.PlayerGameAchievements.ToList());
                */


            }
            catch (Exception e)
            {

                throw;
            }




        }
    }
}
