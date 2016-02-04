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

        public GameAchievementController() {
            GameAchievementProvider = new BLL.Providers.GameAchievementProvider();
        }

        public async Task<DataAccess.Models.GameSchema> Get(long id) {
            var gameAch = await GameAchievementProvider.GetGameAchievements(id, 0);
            return gameAch;
        }
    }
}
