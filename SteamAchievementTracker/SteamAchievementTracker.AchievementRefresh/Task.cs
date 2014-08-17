using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.AchievementRefresh {
    public class AchievementRefreshTask {
        public int RefreshCount { get; set; }
        public int HourRefresh { get; set; }

        public AchievementRefreshTask(int rc, int hr) {
            this.RefreshCount = rc;
            this.HourRefresh = hr;
        }

        public async Task Run(ulong steamID64, string steamID, IProgress<string> progress) {

            App.DataAccess.Repository.PlayerLibraryRepository _libraryRepo = new App.DataAccess.Repository.PlayerLibraryRepository("SteamApp.db");
            var playerLibrary = await _libraryRepo.GetPlayerLibraryCached(steamID64, steamID);

            App.DataAccess.Repository.PlayerStatsRepository _statRepo = new App.DataAccess.Repository.PlayerStatsRepository();

            //Exit loop if player has no library
            if (playerLibrary == null || playerLibrary.Count() == 0) return;

            var gameList = playerLibrary.OrderByDescending(x => x.RecentHours).ToList();

            if (this.RefreshCount > 0) {
                gameList = gameList.Take(this.RefreshCount).ToList();
            }

            int listCount = gameList.Count();
            int counter = 0;

            foreach (var game in gameList) {
                if (!string.IsNullOrEmpty(game.StatsLink)) {
                    var stats = await _statRepo.GetPlayerStats(game.StatsLink);
                    //Determine if we want to update

                    if (DoRefresh(game)) {
                        await _statRepo.RefreshData(game.StatsLink);
                        await Task.Delay(1000);
                    }

                }
                counter++;
                if (progress != null) {
                    progress.Report(string.Format("Updating: {0} out of {1}", counter, listCount));
                }

            }

        }


        private bool DoRefresh(SteamAchievementTracker.App.DataAccess.Model.Game game) {
            DateTime refreshDate = DateTime.Now.AddHours(-this.HourRefresh);
            DateTime refreshDateExtended = DateTime.Now.AddHours(-this.HourRefresh * 3);

            //Game hasn't been updated before
            if (game.AchievementRefresh == DateTime.MinValue) {
                return true;
            }


            //Recently played game force update
            if (game.RecentHours > 0 && game.AchievementRefresh < refreshDate)
            {
                return true;
            }


            //Game has been played, but not recently
            if (game.HoursPlayed > 0 && game.AchievementRefresh < refreshDateExtended)
            {
                return true;
            }


            return false;
        }
    }
}
