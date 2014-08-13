using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.App.DataAccess.Repository {
    public class PlayerStatsRepository {
        public Data.GameAchievement _db;
        public Data.Game _gDB;
        public  PlayerStatsRepository() {
            _db = new Data.GameAchievement();
            _gDB = new Data.Game();
        }

        public async Task<SteamAPI.Models.playerstats> GetPlayerStats(string statURL) {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();
            request.GameUrl = statURL;
            var response = await request.GetResponse();

            return response.PlayerStats;
        }

        public List<Model.GameAchievement> GetGameAchievementsCached(string statURL) {
            var stats = _db.GetAllItems().Where(x => x.StatsURL == statURL).ToList();

            return stats;
        }

        public Model.GameAchievement GetGameAchievementCached(string statURL, string apiName) {
            return _db.GetItem(new KeyValuePair<string,string>(statURL, apiName));
        }


        public void InstertGame(Model.GameAchievement ga) {
            _db.InsertItem(ga);
        }

        public void UpdateGame(Model.GameAchievement ga, string statURL, string apiName) {
            _db.UpdateItem(new KeyValuePair<string, string>(statURL, apiName), ga);
        }


        public async Task<bool> RefreshData(string statURL) {
            var stats = await GetPlayerStats(statURL);

            Model.GameAchievement game;
            if (stats.achievements != null) {
                foreach (var stat in stats.achievements) {
                    var tempStat = _db.GetItem(new KeyValuePair<string, string>(statURL, stat.apiname));

                    game = new Model.GameAchievement(stat, statURL);
                    if (tempStat == null) {
                        _db.InsertItem(game);
                    } else {
                        _db.UpdateItem(new KeyValuePair<string, string>(statURL, stat.apiname), game);
                    }
                }

                //Update DB Flags for game library

                _gDB.UpdateGameStats(statURL, stats.achievements.ToList().Where(x => x.closed == true).Count(), stats.achievements.Count());
            }


            return true;
        }
    }
}
