using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SteamAchievementTracker.Contracts.Models;
using SteamAchievementTracker.BLL.Converters.ServiceToModel;

namespace SteamAchievementTracker.BLL.Providers
{
    public class PlayerGamceAchievementProvider : BaseProvider
    {
        public async Task<DataAccess.Models.PlayerGame> GetAppAchievementsForPlayer(long steamId, long appId)
        {
            var db = new DataAccess.ModelContext();
            DataAccess.Models.PlayerGame pg = db.PlayerGames.Include(x => x.PlayerGameAchievements).Where(x => x.AppID == appId && x.SteamId == steamId).FirstOrDefault();

            if (pg == null)
            {
                db.Dispose();
                return null;
            }

            if (pg.PlayerGameAchievements == null || ExperationService.areAchievementsExpired(pg.AchievementRefresh))
            {
                var playerAchievementsReq = new SteamApiWrapper.SteamUserStats.GetPlayerAchievementsRequest(base.APIKey);
                playerAchievementsReq.appid = (int)appId;
                playerAchievementsReq.SteamId = steamId;
                playerAchievementsReq.l = "en";

                var playerAchievementsResponse = await playerAchievementsReq.GetResponse();

                if (playerAchievementsResponse.Status == SteamApiWrapper.ResponseStatus.ResponseStatusCode.OK)
                {

                    var x = playerAchievementsResponse.PlayerStats.achievements;

                    if (x != null)
                    {
                        pg = ProcessGameAchievements(db, appId, steamId, pg, x.ToList());
                    }
                    else
                    {
                        pg = null;
                    }
                }
                else
                {
                    pg = null;
                }

            }
            db.Dispose();
            return pg;
        }

        public DataAccess.Models.PlayerGame ProcessGameAchievements(DataAccess.ModelContext db, long appId, long steamId, DataAccess.Models.PlayerGame game, List<SteamApiWrapper.Models.PlayerAchievements.Achievement> achievements)
        {
            foreach (var ach in achievements)
            {
                var gameAch = game.PlayerGameAchievements.Where(x => x.ApiName == ach.apiname).FirstOrDefault();
                if (gameAch == null)
                {
                    gameAch = new DataAccess.Models.PlayerGameAchievement();
                    game.PlayerGameAchievements.Add(gameAch);
                    gameAch.Achieved = false;
                }

                //Educated guess of unlock
                if (!gameAch.Achieved && ach.achieved == 1)
                {
                    gameAch.UnlockTimestamp = DateTime.Now;
                }
                gameAch.ConvertService(appId, steamId, ach);

            }
            game.RefreshAchievements = false;
            game.AchievementRefresh = DateTime.Now;

            game.AchievementsEarned = game.PlayerGameAchievements.Where(x => x.Achieved == true).Count();
            game.AchievementsLocked = game.PlayerGameAchievements.Where(x => x.Achieved != true).Count();
            game.TotalAchievements = game.PlayerGameAchievements.Count();

            db.SaveChanges();

            return game;
        }
    }
}
