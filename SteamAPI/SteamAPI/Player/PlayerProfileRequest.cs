using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;

namespace SteamAPI.Player {
    public class PlayerProfileRequest : Request {
        public Models.Profile Profile { get; set; }
        public PlayerProfileRequest() { }

        public async Task<PlayerProfileResponse> GetResponse(string playerUrl, int timeout = 30) {
            string response = await Helpers.WebRequestHelper.ExecuteGetRequest(playerUrl, timeout);

            Models.Profile profile = response.ParseXML<Models.Profile>();





        }
    }
}
