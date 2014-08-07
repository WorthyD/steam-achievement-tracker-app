using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Repository {
    public class PlayerLibraryRepository {
        public Data.Game _db;

        public PlayerLibraryRepository() {
            _db = new Data.Game();
        }

        public async Task<SteamAPI.Models.gamesList> GetPlayerLibrary(string steamID) {
            SteamAPI.Player.PlayerGamesRequest request = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = steamID;
            var response = await request.GetResponse();

            return response.GamesList;
        }

        public async Task<List<Model.Game>> GetPlayerLibraryCached(ulong steamID64, string steamID) {
            //TODO: make this prettier
            //validate cache
            var gl = _db.GetAllItems().Where(x => x.SteamUserID == steamID64).ToList();
            var steamGameList = await GetPlayerLibrary(steamID);


            if (gl == null || gl.Count() != steamGameList.games.Count()) {
                //Games don't exist in DB or are out of sync

                gl = new List<Model.Game>();


                foreach (var g in steamGameList.games) {
                    var tGame = _db.GetItem(new KeyValuePair<ulong, ulong>(steamID64, g.appID));

                    if (tGame == null) {
                        tGame = new Model.Game(g, steamID64);
                        _db.InsertItem(tGame);
                    } else {
                        _db.UpdateItem(new KeyValuePair<ulong, ulong>(steamID64, tGame.AppID), new Model.Game(g, steamID64));
                    }

                    gl.Add(tGame);

                }


            }

            return gl;

        }

    }
}
