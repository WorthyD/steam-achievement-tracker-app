using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.Services.Data
{
    public class PlayerLibraryService : BaseService, IPlayerLibraryService
    {
        public SteamAchievementTracker.App.DataAccess.Data.Game _db;
        //public string DBName = "SteamAchievementTracker.db";

        public PlayerLibraryService()
        {
            _db = new SteamAchievementTracker.App.DataAccess.Data.Game(Settings.Database.DataBaseName);
        }

        public async Task<SteamAPI.Models.gamesList> GetPlayerLibrary(string steamID)
        {
            SteamAPI.Player.PlayerGamesRequest request = new SteamAPI.Player.PlayerGamesRequest();
            request.SteamID = steamID;
            var response = await request.GetResponse();

            return response.GamesList;
        }

        public List<IGame> GetPlayerRecentlyPlayedGames(long steamID64, List<string> gameLinks)
        {
            List<IGame> g = new List<IGame>();

            foreach (var gl in gameLinks)
            {
                g.Add(_db.GetGameBySteamIDAndUrl(steamID64, gl));
            }
            return g;
        }


        public async Task<List<IGame>> GetPlayerLibraryCached(long steamID64)
        {
            var gl = _db.GetGamesBySteamID(steamID64);
            return gl;
        }
        public IStatistics GetPlayerStats(long steamID64)
        {
            return _db.GetStats(steamID64);
        }


        public async Task<List<IGame>> GetPlayerLibraryRefresh(long steamID64, string steamID)
        {
            //validate cache
            var steamGameList = await GetPlayerLibrary(steamID);


            //Games don't exist in DB or are out of sync

            var gl = new List<IGame>();


            foreach (var g in steamGameList.games)
            {
                var tGame = _db.GetItem(new KeyValuePair<long, long>(steamID64, g.appID));

                if (tGame == null)
                {
                    tGame = new Model.Game(g, steamID64);
                    tGame.RefreshAchievements = (tGame.HoursPlayed > 0);
                    tGame.HasAchievements = (!string.IsNullOrEmpty(tGame.StatsLink));
                    _db.InsertItem(tGame);
                }
                else
                {
                    //var ng =  new Model.Game(g, steamID64);
                    //Has user played game since last time.
                    if (g.hoursOnRecordSpecified && (tGame.HoursPlayed != g.hoursOnRecord))
                    {
                        tGame.RefreshAchievements = true;
                        tGame.HoursPlayed = g.hoursOnRecord;
                        if (g.hoursLast2WeeksSpecified) {
                            tGame.RecentHours = g.hoursLast2Weeks;
                        }
                    }
                    

                    _db.UpdateItem(new KeyValuePair<long, long>(steamID64, tGame.AppID), tGame);
                }

                gl.Add(tGame);

            }

            return gl;

        }

        public void UpdateGameStats(string statsUrl, int achievementsEarned, int totalAchievements)
        {
            _db.UpdateGameStats(statsUrl, achievementsEarned, totalAchievements);
        }




        public IGame GetGameByID(long appID, long userId)
        {
            return _db.GetItem(new KeyValuePair<long, long>(userId, appID));
        }
    }
}
