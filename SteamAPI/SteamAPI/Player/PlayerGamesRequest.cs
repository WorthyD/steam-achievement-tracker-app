using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;

namespace SteamAPI.Player {
    public class PlayerGamesRequest : Request {
        public string SteamID { get; set; }

        public PlayerGamesRequest() { }

        public async Task<PlayerGamesResponse> GetResponse(int timeout = 30) {
            string gamesUrl =  string.Format("{0}/games/?xml=1", Helpers.SteamProfileURLBuilder.BuildProfileURL(SteamID));

            string responseString = await Helpers.WebRequestHelper.ExecuteGetRequest(gamesUrl, timeout);

            Models.gamesList gList = responseString.ParseXML<Models.gamesList>();

            PlayerGamesResponse response = new PlayerGamesResponse(this) { GamesList = gList };

            return response;
        }
    }
}
