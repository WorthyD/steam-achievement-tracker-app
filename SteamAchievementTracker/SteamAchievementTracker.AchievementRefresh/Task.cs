using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.AchievementRefresh {
    public class AchievementRefreshTask {
        public int RefreshCount { get; set; }
        public int HourRefresh { get; set; }


        public async void Run(ulong steamID64, string steamID, IProgress<string> progress) {
            //App.DataAccess.Repository.PlayerProfileRepository _playerRepo = new App.DataAccess.Repository.PlayerProfileRepository();

            //var player = await _playerRepo.GetProfileCached(steamID64, steamID);

            App.DataAccess.Repository.PlayerLibraryRepository _libraryRepo = new App.DataAccess.Repository.PlayerLibraryRepository();
            var playerLibrary = await _libraryRepo.GetPlayerLibraryCached(steamID64, steamID);

            App.DataAccess.Repository.PlayerStatsRepository _statRepo = new App.DataAccess.Repository.PlayerStatsRepository();

            //Exit loop if player has no library
            if (playerLibrary == null || playerLibrary.Count() == 0) return;

            var gameList = playerLibrary.OrderByDescending(x => x.RecentHours).ToList();

            if (this.RefreshCount > 0) {
                gameList = gameList.Take(this.RefreshCount).ToList();
            }

            foreach (var game in gameList) {
                if (!string.IsNullOrEmpty(game.StatsLink)) {
                    var stats = await _statRepo.GetPlayerStats(game.StatsLink);
                    //Determine if we want to update

                    if (DoRefresh(game)) {
                        await _statRepo.RefreshData(game.StatsLink);
                    }

                    //Thread.Sleep
                    Thread.Sleep(200);

                    

                    if (progress != null) {
                        progress.Report(string.Format(""));
                    }
                }
            }
            
        }


        private bool DoRefresh(SteamAchievementTracker.App.DataAccess.Model.Game game) {
            DateTime refreshDate = DateTime.Now.AddHours(-this.HourRefresh);

            if (game.LastUpdated < refreshDate) {
                return true;
            }


            return false;
        }
    }
}
