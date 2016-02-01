using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SteamAchievementTracker.WebApi.Controllers
{
    public class PlayerProfileController : ApiController
    {
        public BLL.Providers.PlayerProvider PlayerProvider {get;set;}
        public PlayerProfileController()
        {
            PlayerProvider = new BLL.Providers.PlayerProvider();
        }

        public async Task<ViewModels.PlayerProfile> Get(long id)
        {
            var profile = await PlayerProvider.GetProfileFromLogin(id);
            return new ViewModels.PlayerProfile(profile);
        }
    }
}
