using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Player {
    public class PlayerProfileResponse : Response<PlayerProfileRequest> {
        public Models.Profile.profile Profile { get; set; }
        public PlayerProfileResponse() { }
        public PlayerProfileResponse(PlayerProfileRequest request) : base(request) { }
    }
}
