using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace SteamAchievementTracker.WebApp.Controllers.Api {

    public class UserProfileController : ApiController {
        //[HttpGet]
        public async Task<SteamAPI.ViewModels.ProfileViewModel> Get(string id) {
            SteamAPI.Player.PlayerProfileRequest request = new SteamAPI.Player.PlayerProfileRequest();
            request.SteamID = id; 
            var response = await request.GetLightResponse();
            return response;
        }
    }
}
