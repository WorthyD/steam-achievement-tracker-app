using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Providers
{
    public class BaseProvider
    {
        public string APIKey { get; set; }

        public BaseProvider(string APIKey)
        {
            this.APIKey = APIKey;
        }
        public BaseProvider()
        {
            this.APIKey = ConfigurationManager.AppSettings["APIKey"];
        }

    }
}
