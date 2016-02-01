using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SteamAchievementTracker.WebApi.Controllers
{
    public class PlayerLibraryController : ApiController
    {
        public BLL.Providers.PlayerLibraryProvider LibraryProvider { get; set; }
        public PlayerLibraryController()
        {
            LibraryProvider = new BLL.Providers.PlayerLibraryProvider();
        }

        public async Task<ViewModels.PlayerLibrary> Get(long id)
        {
            var games = await LibraryProvider.GetPlayerLibrary(id);
            return new ViewModels.PlayerLibrary(games);
        }
    }
}
