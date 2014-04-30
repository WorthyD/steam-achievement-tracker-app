using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using PetFinderAPI.Helpers;
using PetFinderAPI.Extensions;

namespace PetFinderAPI.Breed {
    public class BreedListRequest : Request {

        public Models.animalType AnimalType { get; set; }

        public BreedListRequest() {
        }


        public BreedListResponse GetResponse(ServiceConfiguration config, int timeout = 30) {

            if (config == null) {
                throw new ArgumentNullException("config");
            }
            if (this.AnimalType == null) {
                throw new ArgumentNullException("AnimalType");
            }

            string breedListData = string.Empty;
            this.ApiKey = config.ApiKey;
            string url = this.GetServiceUrl(config);
            breedListData = WebRequestHelper.ExecuteGetRequest(url, timeout);
            //Models.BreedList breedList = breedListData.FromJson<Models.BreedList>();
            Models.petfinder breedList = breedListData.ParseXML<Models.petfinder>();

            BreedListResponse response = new BreedListResponse(this) { BreedList = breedList.Item as Models.petfinderBreedList };
            response.Status = ResponseStatus.Convert(breedList.header.status.code);
            response.StatusMessage = breedList.header.status.message;
            return response;
        }

        internal string GetServiceUrl(ServiceConfiguration config) {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> queryString = new System.Collections.Generic.Dictionary<string, string>();
            sb.AppendFormat("{0}/breed.list", config.WebServiceBaseURL);

            //token

            queryString.Add("key", config.ApiKey);
            queryString.Add("animal", AnimalType.ToString().ToLower());
            //queryString.Add("format", config.Format);
            sb.Append(queryString.FormatQuerystring());

            return sb.ToString();
        }
    }
}
