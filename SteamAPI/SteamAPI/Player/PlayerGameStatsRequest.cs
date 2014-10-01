using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;
using System.Diagnostics;

namespace SteamAPI.Player
{
    public class PlayerGameStatsRequest : Request
    {
        public string GameUrl { get; set; }

        public PlayerGameStatsRequest() { }

        public async Task<PlayerGameStatsResponse> GetResponse(int timeout = 30)
        {
            string formattedGameUrl = string.Format("{0}?xml=1", GameUrl);
            string responseString = await Helpers.WebRequestHelper.ExecuteGetRequest(formattedGameUrl, timeout);
            PlayerGameStatsResponse response = new PlayerGameStatsResponse(this);
            try
            {
                Models.playerstats stats = responseString.ParseXML<Models.playerstats>();
                response = new PlayerGameStatsResponse(this) { PlayerStats = stats };
            }
            catch (Exception)
            {
                Debug.WriteLine("Error parsing " + formattedGameUrl);
            }

            return response;
        }

    }
}
