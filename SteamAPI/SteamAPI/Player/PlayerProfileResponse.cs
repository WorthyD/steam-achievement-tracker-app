using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Player {
    public class GetPlayerProfileResponse : Response<PlayerProfileRequest> {

        public GetPlayerProfileResponse() { }
        public GetPlayerProfileResponse(PlayerProfileRequest request) : base(request) { }
    }
}
