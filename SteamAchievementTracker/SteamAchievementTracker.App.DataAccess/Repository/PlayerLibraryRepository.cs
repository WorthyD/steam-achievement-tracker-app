using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Repository {
    public class PlayerLibraryRepository {
        public async Task<SteamAPI.Models.gamesList> GetPlayerLibrary(string steamID){
            SteamAPI.Player.PlayerGamesRequest request = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = steamID;
            var response = await request.GetResponse();

            return response.GamesList;
        }
    }
}
