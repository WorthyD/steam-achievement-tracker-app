﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAPI.Extensions;

namespace SteamAPI.Player {
    public class PlayerProfileRequest : Request {
        public string SteamID { get; set; }


        public PlayerProfileRequest() { }

        public async Task<PlayerProfileResponse> GetResponse(int timeout = 30) {
            string playerUrl = string.Format("{0}?xml=1", Helpers.SteamProfileURLBuilder.BuildProfileURL(SteamID));

            string response = await Helpers.WebRequestHelper.ExecuteGetRequest(playerUrl, timeout);

            Models.Profile.profile profile = response.ParseXML<Models.Profile.profile>();

            PlayerProfileResponse profileResponse = new PlayerProfileResponse(this) { Profile = profile };

            return profileResponse;
        }
    }
}
