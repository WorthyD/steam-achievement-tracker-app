using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPI.Player {
    public class PlayerGameStatsResponse : Response<PlayerGameStatsRequest> {
        public Models.playerstats PlayerStats { get; set; }
        public PlayerGameStatsResponse() { }

        public PlayerGameStatsResponse(PlayerGameStatsRequest request) : base(request) { 
            this.PlayerStats = new Models.playerstats(); 
        }

    }
}
