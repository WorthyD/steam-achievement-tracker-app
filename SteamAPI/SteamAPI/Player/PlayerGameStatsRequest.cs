using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;
using System.Diagnostics;
using SteamAPI.Converters;
namespace SteamAPI.Player
{
    public class PlayerGameStatsRequest : Request
    {
        public string GameUrl { get; set; }

        public PlayerGameStatsRequest() { }

        public async Task<PlayerGameStatsResponse> GetResponse(int timeout = 30)
        {
            string formattedGameUrl = string.Format("{0}?xml=1", GameUrl);

            Debug.WriteLine(string.Format("Calling: {0}", formattedGameUrl));
            string responseString = await Helpers.WebRequestHelper.ExecuteGetRequest(formattedGameUrl, timeout);
            PlayerGameStatsResponse response = new PlayerGameStatsResponse(this);
            try
            {
                Models.playerstats stats = responseString.StringToStatsList();
                response = new PlayerGameStatsResponse(this) { PlayerStats = stats };
            }
            catch (Exception)
            {
                throw new Exceptions.PlayerGameStatParseException();

                Debug.WriteLine("Error parsing {0} " + formattedGameUrl);
            }

            return response;
        }

    }
}
