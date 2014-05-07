using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;

namespace SteamAPI.Player {
    public class PlayerGameStatsRequest : Request {
        public string GameUrl { get; set; }

        public PlayerGameStatsRequest() { }

        public async Task<PlayerGameStatsResponse> GetResponse(int timeout = 30) {
            string formattedGameUrl = string.Format("{0}?xml=1", GameUrl);
            string responseString = await Helpers.WebRequestHelper.ExecuteGetRequest(formattedGameUrl, timeout);

            Models.playerstats stats = responseString.ParseXML<Models.playerstats>();

            PlayerGameStatsResponse response = new PlayerGameStatsResponse(this) { PlayerStats = stats };

            return response;
        }

    }
}
