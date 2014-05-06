using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Helpers {
    public class SteamProfileURLBuilder {
        private const string BaseURL = "http://steamcommunity.com/";
        // http://steamcommunity.com/profiles/76561197968575517/?xml=1
        // http://steamcommunity.com/id/ChetFaliszek/?xml=1

        public static string BuildProfileURL(string steamID){
            int profile64 = 0;
            int.TryParse(steamID, out profile64);
            string midPath = "id/";

            if (profile64 < 0) {
                midPath = "profiles/";
            }

            return string.Format("{0}{1}{2}", BaseURL, midPath, steamID);
        }

    }
}
