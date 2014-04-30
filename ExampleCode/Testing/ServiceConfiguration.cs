using System;


namespace PetFinderAPI {
    public class ServiceConfiguration {
        public string WebServiceBaseURL { get; set; }

        public string ApiKey { get; set; }

        public string Format { get; set; }

        public ServiceConfiguration() {
            this.Format = "json";
        }


    }
}
