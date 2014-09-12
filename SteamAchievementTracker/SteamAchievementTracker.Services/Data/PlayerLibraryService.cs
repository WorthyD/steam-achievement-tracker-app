using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Services.Data
{
    public class PlayerLibraryService : IPlayerLibraryService
    {
        public SteamAchievementTracker.App.DataAccess.Data.Game _db;
        public string DBName = "SteamAchievementTracker.db";

        public PlayerLibraryService()
        {
            _db = new  SteamAchievementTracker.App.DataAccess.Data.Game(DBName);
        }

        public async Task<SteamAPI.Models.gamesList> GetPlayerLibrary(string steamID) {
            SteamAPI.Player.PlayerGamesRequest request = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = steamID;
            var response = await request.GetResponse();

            return response.GamesList;
        }

        public async Task<List<IGame>> GetPlayerRecentlyPlayedGames(long steamID64, string steamID)
        {
            var games = await GetPlayerLibraryCached(steamID64);
            if (games == null || games.Count() == 0)
            {
                games = await GetPlayerLibraryRefresh(steamID64, steamID);
            }

            return games.Where(x => x.RecentHours > 0).ToList();
        }


        public async Task<List<IGame>> GetPlayerLibraryCached(long steamID64)
        {
            //var gl = _db.GetAllItems().Where(x => x.SteamUserID == steamID64).ToList();
            var gl = _db.GetGamesBySteamID(steamID64);
            return gl;
        }


        public async Task<List<IGame>> GetPlayerLibraryRefresh(long steamID64, string steamID) {
            //validate cache
            var gl = await GetPlayerLibraryCached(steamID64);
            var steamGameList = await GetPlayerLibrary(steamID);


            if (gl == null || gl.Count() != steamGameList.games.Count()) {
                //Games don't exist in DB or are out of sync

                gl = new List<IGame>();


                foreach (var g in steamGameList.games) {
                    var tGame = _db.GetItem(new KeyValuePair<long, long>(steamID64, g.appID));

                    if (tGame == null) {
                        tGame = new Model.Game(g, steamID64);
                        //tGame = new Model.Game(g, steamID64);
                        _db.InsertItem(tGame);
                    } else {
                        _db.UpdateItem(new KeyValuePair<long, long>(steamID64, tGame.AppID), new Model.Game(g, steamID64));
                    }

                    gl.Add(tGame);

                }


            }

            return gl;

        }

        public void UpdateGameStats(string statsUrl, int achievementsEarned, int totalAchievements) {
            _db.UpdateGameStats(statsUrl, achievementsEarned, totalAchievements);
        }
    
    }
}
