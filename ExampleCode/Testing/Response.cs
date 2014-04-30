using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetFinderAPI;

namespace PetFinderAPI {
    public abstract class Response<T> where T : new() {
        public PetFinderAPI.ResponseStatus.ResponseStatusCode Status { get; set; }
        public string StatusMessage { get; set; }
        public T Request { get; set; }

        public Response() {
            Request = new T();
            Status = PetFinderAPI.ResponseStatus.ResponseStatusCode.Ok;

        }

        public Response(T request, PetFinderAPI.ResponseStatus.ResponseStatusCode status, string statusMessage) {
            Request = request;
            Status = status;
            StatusMessage = statusMessage;
        }

        public Response(T request) {
            Request = request;
            Status = PetFinderAPI.ResponseStatus.ResponseStatusCode.Ok;
            StatusMessage = string.Empty;
        }

        public Response(PetFinderAPI.ResponseStatus.ResponseStatusCode status, string statusMessage) {
            Request = new T();
            Status = status;
            StatusMessage = statusMessage;
        }
    }
}
