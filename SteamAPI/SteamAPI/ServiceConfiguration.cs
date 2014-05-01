using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI {
    public class ServiceConfiguration {
            public string WebServiceBaseURL { get; set; }

            public string ApiKey { get; set; }

            public string Format { get; set; }

            public ServiceConfiguration() {
                this.Format = "json";
            }


    }
}
