using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;
using System.Diagnostics;
using SteamAPI.Converters;

namespace SteamAPI.Player {
    public class PlayerGamesRequest : Request {
        public string SteamID { get; set; }

        public PlayerGamesRequest() { }

        public async Task<PlayerGamesResponse> GetResponse(int timeout = 30) {
            string gamesUrl =  string.Format("{0}/games/?xml=1", Helpers.SteamProfileURLBuilder.BuildProfileURL(SteamID));

            Debug.WriteLine(string.Format("Calling: {0}", gamesUrl));
            string responseString = await Helpers.WebRequestHelper.ExecuteGetRequest(gamesUrl, timeout);

            Models.gamesList gList = responseString.StringToGameList();//.ParseXML<Models.gamesList>();
            Debug.WriteLine(string.Format("Recieved: {0}", gamesUrl));

            PlayerGamesResponse response = new PlayerGamesResponse(this) { GamesList = gList };

            return response;
        }
    }
}
