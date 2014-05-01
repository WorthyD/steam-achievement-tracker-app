using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Helpers {
    public class WebRequestHelper {

        public string ExecuteGetRequest(string url, int timeout = 30) {
            //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                         
            // // IF YOU DON'T INIT THE COOKIE CONTAINER, YOU DON'T GET COOKIES IN THE RESPONSE            
            // //req.CookieContainer = _cachedCookies;
 
            // req.Method = "GET";
            // //req.Timeout = timeout * 1000;
 
            // //using (HttpWebResponse resp = ((HttpWebResponse)req.BeginGetResponse)))
            // //{
                
             
            // //    return resp.ConvertToString();
            // //}

            //HttpClient client = new 
            var req = WebRequest.Create("");
            //await req.GetRequestStreamAsync();
            return "";
        }

    }
}
