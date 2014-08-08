using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.AchievementRefresh {
    public class AchievementRefreshTask {
        public async void Run(ulong steamID64) {
            App.DataAccess.Repository.PlayerProfileRepository _playerRepo = new App.DataAccess.Repository.PlayerProfileRepository();

            var player = await _playerRepo.GetProfileFromDB(steamID64);

            App.DataAccess.Repository.PlayerLibraryRepository _libraryRepo = new App.DataAccess.Repository.PlayerLibraryRepository();
            var playerLibrary = await _libraryRepo.GetPlayerLibrary(player.ID);

            App.DataAccess.Repository.PlayerStatsRepository _statRepo = new App.DataAccess.Repository.PlayerStatsRepository();

            foreach (var game in playerLibrary.games) {
                var stats = await _statRepo.GetPlayerStats(game.statsLink);

                App.DataAccess.Model.GameAchievement tgame;
                foreach (var stat in stats.achievements) {
                    var tempStat = _db.GetItem(new KeyValuePair<string, string>(statURL, stat.apiname));

                    tgame = new Model.GameAchievement(stat, statURL);
                    if (tempStat == null) {
                        _db.InsertItem(game);
                    } else {
                        _db.UpdateItem(new KeyValuePair<string, string>(statURL, stat.apiname), game);
                    }
                }

            }
            
        }
    }
}
