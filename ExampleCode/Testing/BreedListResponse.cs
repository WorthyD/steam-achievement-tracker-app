using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetFinderAPI.Breed {
    public class BreedListResponse : Response<BreedListRequest> {
        public Models.petfinderBreedList BreedList { get; set; }

        public BreedListResponse() { }


        public BreedListResponse(BreedListRequest request, PetFinderAPI.ResponseStatus.ResponseStatusCode status, string statusMessage) : base(request, status, statusMessage) { }
        public BreedListResponse(BreedListRequest request) : base(request) { }
    }
}
