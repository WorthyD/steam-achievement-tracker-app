using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Text;
using Microsoft;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
namespace SteamAPI.Helpers {
    public class WebRequestHelper {
        public static async Task<string> ExecuteGetRequest(string url, int timeout = 30) {

            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);

            return result;
        }

    }
}
