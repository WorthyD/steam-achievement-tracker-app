using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Player {
    public class PlayerGamesResponse : Response<PlayerGamesRequest>{
        public Models.gamesList GamesList { get; set; }
        public PlayerGamesResponse() { }
        public PlayerGamesResponse(PlayerGamesRequest request): base(request) { }
    }
}
