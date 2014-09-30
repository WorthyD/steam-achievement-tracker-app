using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAchievementTracker.App.DataAccess;
using SteamAchievementTracker.Contracts.Model;
using SteamAchievementTracker.Contracts.Services;
using System.Diagnostics;

namespace SteamAchievementTracker.Services.Data
{
    public class PlayerStatsService : IPlayerStatsService
    {
        public SteamAchievementTracker.App.DataAccess.Data.GameAchievement _db;
        public SteamAchievementTracker.App.DataAccess.Data.Game _gDB;
        public PlayerStatsService()
        {
            _db = new SteamAchievementTracker.App.DataAccess.Data.GameAchievement(Settings.Database.DataBaseName);

            _gDB = new SteamAchievementTracker.App.DataAccess.Data.Game(Settings.Database.DataBaseName);

        }

        public async Task<SteamAPI.Models.playerstats> GetPlayerStats(string statURL)
        {
            SteamAPI.Player.PlayerGameStatsRequest request = new SteamAPI.Player.PlayerGameStatsRequest();
            request.GameUrl = statURL;
            var response = await request.GetResponse();

            return response.PlayerStats;
        }

        public List<IGameAchievement> GetGameAchievementsCached(string statURL)
        {
            //var stats = _db.GetAllItems().Where(x => x.StatsURL == statURL).ToList();
            var stats = _db.GetByStatsUrl(statURL).ToList();

            return stats;
        }

        public IGameAchievement GetGameAchievementCached(string statURL, string apiName)
        {
            return _db.GetItem(new KeyValuePair<string, string>(statURL, apiName));
        }


        public void InstertGame(IGameAchievement ga)
        {
            _db.InsertItem(ga);
        }

        public void UpdateGame(IGameAchievement ga, string statURL, string apiName)
        {
            _db.UpdateItem(new KeyValuePair<string, string>(statURL, apiName), ga);
        }


        public async Task<bool> RefreshData(string statURL)
        {
            var stats = await GetPlayerStats(statURL);

            Model.GameAchievement game;
            if (stats.achievements != null)
            {
                foreach (var stat in stats.achievements)
                {
                    var tempStat = _db.GetItem(new KeyValuePair<string, string>(statURL, stat.apiname));

                    game = new Model.GameAchievement(stat, statURL);
                    if (tempStat == null)
                    {
                        _db.InsertItem(game);
                    }
                    else
                    {
                        _db.UpdateItem(new KeyValuePair<string, string>(statURL, stat.apiname), game);
                    }
                }

                //Update DB Flags for game library

                _gDB.UpdateGameStats(statURL, stats.achievements.ToList().Where(x => x.closed == true).Count(), stats.achievements.Count());
            }


            return true;
        }
        public async Task<List<IGameAchievement>> GetFreshStats(string statURL)
        {

            var stats = await GetPlayerStats(statURL);
            List<IGameAchievement> ach = new List<IGameAchievement>();
            Model.GameAchievement game;
            if (stats.achievements != null)
            {
                foreach (var stat in stats.achievements)
                {
                    var tempStat = _db.GetItem(new KeyValuePair<string, string>(statURL, stat.apiname));

                    game = new Model.GameAchievement(stat, statURL);
                    if (tempStat == null)
                    {
                        _db.InsertItem(game);
                    }
                    else
                    {
                        _db.UpdateItem(new KeyValuePair<string, string>(statURL, stat.apiname), game);
                    }
                    ach.Add(game);
                }

                //Update DB Flags for game library

                _gDB.UpdateGameStats(statURL, stats.achievements.ToList().Where(x => x.closed == true).Count(), stats.achievements.Count());
            }
            return ach;
        }

        //public 
        public async Task UpdateStatsByList(List<string> statUrls, IProgress<string> progress)
        {

            int counter = 0;
            foreach (var statUrl in statUrls)
            {
                Debug.WriteLine("Getting Stats for" + statUrl);
                await GetFreshStats(statUrl);
                //todo: settings
                await Task.Delay(1000);

                counter++;
                if (progress != null)
                {
                    progress.Report(string.Format("Updating: {0} out of {1}", counter, statUrls.Count));
                }


            }

        }
    }
}
