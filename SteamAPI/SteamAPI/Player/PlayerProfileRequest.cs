using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;
using System.Diagnostics;

namespace SteamAPI.Player {
    public class PlayerProfileRequest : Request {
        public string SteamID { get; set; }


        public PlayerProfileRequest() { }

        public async Task<PlayerProfileResponse> GetResponse(int timeout = 30) {
            string playerUrl = string.Format("{0}?xml=1", Helpers.SteamProfileURLBuilder.BuildProfileURL(SteamID));
            Debug.WriteLine(string.Format("Calling: {0}", playerUrl));
            string response = await Helpers.WebRequestHelper.ExecuteGetRequest(playerUrl, timeout);
            PlayerProfileResponse profileResponse = new PlayerProfileResponse();
            try
            {
                Models.Profile.profile profile = response.ParseXML<Models.Profile.profile>();
                Debug.WriteLine(string.Format("Received: {0}", playerUrl));

                profileResponse = new PlayerProfileResponse(this) { Profile = profile };
            }
            catch (Exception e)
            {
                Debug.WriteLine(string.Format("Error Getting Profile: {0}  ||||||||||||||| {1}", e.Message, e.InnerException.Message));
                throw new Exceptions.PlayerNotFoundException();
            }

            return profileResponse;
        }
    }
}
