using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace SteamAchievementTracker.WebApi.Controllers
{
    public class RecentGamesController : ApiController
    {
        public BLL.Providers.RecentGameProvider RecentGameProvider { get; set; }
        public RecentGamesController()
        {
            RecentGameProvider = new BLL.Providers.RecentGameProvider();
        }

        public async Task<List<long>> Get(long id)
        {
            var ids = await RecentGameProvider.GetRecentlyPlayedGames(id);
            return ids.Select(x => x.AppId).ToList();
        }
    }
}
